using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaSeguridad.API.Mapping;
using SistemaSeguridad.Domain.Features.PerfilSistema;
using SistemaSeguridad.Domain.Features.PerfilSistema.Commands.Create;
using SistemaSeguridad.Domain.Features.PerfilSistema.Commands.Delete;
using SistemaSeguridad.Domain.Features.PerfilSistema.Commands.Update;
using SistemaSeguridad.Domain.Features.PerfilSistema.Queries.GetAll;
using SistemaSeguridad.Domain.Features.PerfilSistema.Queries.GetById;

namespace SistemaSeguridad.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilSistemaController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public PerfilSistemaController(IMediator mediator)
        {
            _mediator = mediator;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        [HttpGet]
        public async Task<IActionResult> GetPerfilSistemas()
        {
            return Ok(await _mediator.Send(new GetAllPerfilSistemaQuery()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPerfilSistema(int id)
        {
            return Ok(await _mediator.Send(new GetPerfilSistemaByIdQuery(id)));
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> PostPerfilSistema(PerfilSistemaResponse perfilSistema)
        {
            return Ok(await _mediator.Send(_mapper.Map<CreatePerfilSistemaCommand>(perfilSistema)));
        }

        [HttpPut]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> PutPerfilSistema(PerfilSistemaResponse perfilSistema)
        {
            return Ok(await _mediator.Send(_mapper.Map<UpdatePerfilSistemaCommand>(perfilSistema)));
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> DeletePerfilSistema(int id)
        {
            return Ok(await _mediator.Send(new DeletePerfilSistemaCommand(id)));
        }

    }
}
