using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaSeguridad.API.Mapping;
using SistemaSeguridad.Domain.Features.Perfil;
using SistemaSeguridad.Domain.Features.Perfil.Commands.Create;
using SistemaSeguridad.Domain.Features.Perfil.Commands.Delete;
using SistemaSeguridad.Domain.Features.Perfil.Commands.Update;
using SistemaSeguridad.Domain.Features.Perfil.Queries.GetAll;
using SistemaSeguridad.Domain.Features.Perfil.Queries.GetById;

namespace SistemaSeguridad.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public PerfilController(IMediator mediator)
        {
            _mediator = mediator;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        [HttpGet]
        public async Task<IActionResult> GetPerfils()
        {
            return Ok(await _mediator.Send(new GetAllPerfilQuery()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPerfil(int id)
        {
            return Ok(await _mediator.Send(new GetPerfilByIdQuery(id)));
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> PostPerfil(PerfilResponse perfil)
        {
            return Ok(await _mediator.Send(_mapper.Map<CreatePerfilCommand>(perfil)));
        }

        [HttpPut]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> PutPerfil(PerfilResponse perfil)
        {
            return Ok(await _mediator.Send(_mapper.Map<UpdatePerfilCommand>(perfil)));
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> DeletePerfil(int id)
        {
            return Ok(await _mediator.Send(new DeletePerfilCommand(id)));
        }

    }
}
