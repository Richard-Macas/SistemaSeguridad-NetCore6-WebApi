using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaSeguridad.API.Mapping;
using SistemaSeguridad.Domain.Features.RecursoPerfil;
using SistemaSeguridad.Domain.Features.RecursoPerfil.Commands.Create;
using SistemaSeguridad.Domain.Features.RecursoPerfil.Commands.Delete;
using SistemaSeguridad.Domain.Features.RecursoPerfil.Commands.Update;
using SistemaSeguridad.Domain.Features.RecursoPerfil.Queries.GetAll;
using SistemaSeguridad.Domain.Features.RecursoPerfil.Queries.GetById;

namespace SistemaSeguridad.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecursoPerfilController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public RecursoPerfilController(IMediator mediator)
        {
            _mediator = mediator;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        [HttpGet]
        public async Task<IActionResult> GetRecursoPerfils()
        {
            return Ok(await _mediator.Send(new GetAllRecursoPerfilQuery()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRecursoPerfil(int id)
        {
            return Ok(await _mediator.Send(new GetRecursoPerfilByIdQuery(id)));
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> PostRecursoPerfil(RecursoPerfilResponse recursoPerfil)
        {
            return Ok(await _mediator.Send(_mapper.Map<CreateRecursoPerfilCommand>(recursoPerfil)));
        }

        [HttpPut]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> PutRecursoPerfil(RecursoPerfilResponse recursoPerfil)
        {
            return Ok(await _mediator.Send(_mapper.Map<UpdateRecursoPerfilCommand>(recursoPerfil)));
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> DeleteRecursoPerfil(int id)
        {
            return Ok(await _mediator.Send(new DeleteRecursoPerfilCommand(id)));
        }

    }
}
