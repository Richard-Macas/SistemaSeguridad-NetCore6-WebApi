using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaSeguridad.API.Mapping;
using SistemaSeguridad.Domain.Features.Recursos;
using SistemaSeguridad.Domain.Features.Recursos.Commands.Create;
using SistemaSeguridad.Domain.Features.Recursos.Commands.Delete;
using SistemaSeguridad.Domain.Features.Recursos.Commands.Update;
using SistemaSeguridad.Domain.Features.Recursos.Queries.GetAllByExpression;
using SistemaSeguridad.Domain.Features.Recursos.Queries.GetById;
using SistemaSeguridad.Domain.Features.Sistema.Queries.GetAllByExpression;

namespace SistemaSeguridad.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecursoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public RecursoController(IMediator mediator)
        {
            _mediator = mediator;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        [HttpGet("RecursoPorSistema/{id:int}")]
        public async Task<IActionResult> ObtenerRecursosPorPerfilYSistema(int id)
        {
            return Ok(await _mediator.Send(new GetAllRecursoByExpressionQuery(User, id)));
        }

        [HttpGet]
        public async Task<IActionResult> GetRecursos()
        {
            return Ok(await _mediator.Send(new GetAllRecursoQuery()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRecurso(int id)
        {
            return Ok(await _mediator.Send(new GetRecursoByIdQuery(id)));
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> PostRecurso(RecursoResponse recurso)
        {
            return Ok(await _mediator.Send(_mapper.Map<CreateRecursoCommand>(recurso)));
        }

        [HttpPut]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> PutRecurso(RecursoResponse recurso)
        {
            return Ok(await _mediator.Send(_mapper.Map<UpdateRecursoCommand>(recurso)));
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> DeleteRecurso(int id)
        {
            return Ok(await _mediator.Send(new DeleteRecursoCommand(id)));
        }
    }
}
