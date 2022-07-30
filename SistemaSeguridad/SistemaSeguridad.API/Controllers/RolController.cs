using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaSeguridad.API.Mapping;
using SistemaSeguridad.Domain.Features.Rol;
using SistemaSeguridad.Domain.Features.Rol.Commands.Create;
using SistemaSeguridad.Domain.Features.Rol.Commands.Delete;
using SistemaSeguridad.Domain.Features.Rol.Commands.Update;
using SistemaSeguridad.Domain.Features.Rol.Queries.GetAll;
using SistemaSeguridad.Domain.Features.Rol.Queries.GetById;

namespace SistemaSeguridad.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public RolController(IMediator mediator)
        {
            _mediator = mediator;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        [HttpGet]
        public async Task<IActionResult> GetRols()
        {
            return Ok(await _mediator.Send(new GetAllRolQuery()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRol(int id)
        {
            return Ok(await _mediator.Send(new GetRolByIdQuery(id)));
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> PostRol(RolResponse rol)
        {
            return Ok(await _mediator.Send(_mapper.Map<CreateRolCommand>(rol)));
        }

        [HttpPut]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> PutRol(RolResponse rol)
        {
            return Ok(await _mediator.Send(_mapper.Map<UpdateRolCommand>(rol)));
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            return Ok(await _mediator.Send(new DeleteRolCommand(id)));
        }

    }
}
