using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaSeguridad.API.Mapping;
using SistemaSeguridad.Domain.Features.Usuario;
using SistemaSeguridad.Domain.Features.Usuario.Commands.Create;
using SistemaSeguridad.Domain.Features.Usuario.Commands.Delete;
using SistemaSeguridad.Domain.Features.Usuario.Commands.Update;
using SistemaSeguridad.Domain.Features.Usuario.Queries.GetAll;
using SistemaSeguridad.Domain.Features.Usuario.Queries.GetById;

namespace SistemaSeguridad.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            return Ok(await _mediator.Send(new GetAllUsuarioQuery()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            return Ok(await _mediator.Send(new GetUsuarioByIdQuery(id)));
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> PostUsuario(UsuarioResponse usuario)
        {
            return Ok(await _mediator.Send(_mapper.Map<CreateUsuarioCommand>(usuario)));
        }

        [HttpPut]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> PutUsuario(UsuarioResponse usuario)
        {
            return Ok(await _mediator.Send(_mapper.Map<UpdateUsuarioCommand>(usuario)));
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            return Ok(await _mediator.Send(new DeleteUsuarioCommand(id)));
        }

    }
}
