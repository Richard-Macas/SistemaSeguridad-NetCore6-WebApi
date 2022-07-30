using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaSeguridad.API.Mapping;
using SistemaSeguridad.Domain.Features.SistemaRecurso;
using SistemaSeguridad.Domain.Features.SistemaRecurso.Commands.Create;
using SistemaSeguridad.Domain.Features.SistemaRecurso.Commands.Delete;
using SistemaSeguridad.Domain.Features.SistemaRecurso.Commands.Update;
using SistemaSeguridad.Domain.Features.SistemaRecurso.Queries.GetAll;
using SistemaSeguridad.Domain.Features.SistemaRecurso.Queries.GetById;

namespace SistemaSeguridad.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SistemaRecursoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public SistemaRecursoController(IMediator mediator)
        {
            _mediator = mediator;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        [HttpGet]
        public async Task<IActionResult> GetSistemaRecursos()
        {
            return Ok(await _mediator.Send(new GetAllSistemaRecursoQuery()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSistemaRecurso(int id)
        {
            return Ok(await _mediator.Send(new GetSistemaRecursoByIdQuery(id)));
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> PostSistemaRecurso(SistemaRecursoResponse sistemaRecurso)
        {
            return Ok(await _mediator.Send(_mapper.Map<CreateSistemaRecursoCommand>(sistemaRecurso)));
        }

        [HttpPut]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> PutSistemaRecurso(SistemaRecursoResponse sistemaRecurso)
        {
            return Ok(await _mediator.Send(_mapper.Map<UpdateSistemaRecursoCommand>(sistemaRecurso)));
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> DeleteSistemaRecurso(int id)
        {
            return Ok(await _mediator.Send(new DeleteSistemaRecursoCommand(id)));
        }

    }
}
