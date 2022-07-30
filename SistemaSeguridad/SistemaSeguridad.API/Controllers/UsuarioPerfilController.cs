using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaSeguridad.API.Mapping;
using SistemaSeguridad.Domain.Features.UsuarioPerfil;
using SistemaSeguridad.Domain.Features.UsuarioPerfil.Commands.Create;
using SistemaSeguridad.Domain.Features.UsuarioPerfil.Commands.Delete;
using SistemaSeguridad.Domain.Features.UsuarioPerfil.Commands.Update;
using SistemaSeguridad.Domain.Features.UsuarioPerfil.Queries.GetAll;
using SistemaSeguridad.Domain.Features.UsuarioPerfil.Queries.GetById;

namespace SistemaSeguridad.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioPerfilController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UsuarioPerfilController(IMediator mediator)
        {
            _mediator = mediator;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarioPerfils()
        {
            return Ok(await _mediator.Send(new GetAllUsuarioPerfilQuery()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUsuarioPerfil(int id)
        {
            return Ok(await _mediator.Send(new GetUsuarioPerfilByIdQuery(id)));
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> PostUsuarioPerfil(UsuarioPerfilResponse usuarioPerfil)
        {
            return Ok(await _mediator.Send(_mapper.Map<CreateUsuarioPerfilCommand>(usuarioPerfil)));
        }

        [HttpPut]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> PutUsuarioPerfil(UsuarioPerfilResponse usuarioPerfil)
        {
            return Ok(await _mediator.Send(_mapper.Map<UpdateUsuarioPerfilCommand>(usuarioPerfil)));
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> DeleteUsuarioPerfil(int id)
        {
            return Ok(await _mediator.Send(new DeleteUsuarioPerfilCommand(id)));
        }

    }
}
