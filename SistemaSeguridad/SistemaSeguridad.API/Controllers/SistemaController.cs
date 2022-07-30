using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaSeguridad.API.Mapping;
using SistemaSeguridad.Domain.Features.Sistema;
using SistemaSeguridad.Domain.Features.Sistema.Commands.Create;
using SistemaSeguridad.Domain.Features.Sistema.Commands.Delete;
using SistemaSeguridad.Domain.Features.Sistema.Commands.Update;
using SistemaSeguridad.Domain.Features.Sistema.Queries.GetAll;
using SistemaSeguridad.Domain.Features.Sistema.Queries.GetAllByExpression;
using SistemaSeguridad.Domain.Features.Sistema.Queries.GetById;

namespace SistemaSeguridad.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SistemaController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public SistemaController(IMediator mediator)
        {
            _mediator = mediator;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        [HttpGet("SistemasPorPerfil")]
        public async Task<IActionResult> GetSistemasPorPerfil()
        {
            return Ok(await _mediator.Send(new GetAllSistemaByExpressionQuery(User)));
        }

        [HttpGet]
        public async Task<IActionResult> GetSistemas()
        {
            return Ok(await _mediator.Send(new GetAllSistemaQuery()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSistema(int id)
        {
            return Ok(await _mediator.Send(new GetSistemaByIdQuery(id)));
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> PostSistema(SistemaResponse sistema)
        {
            return Ok(await _mediator.Send(_mapper.Map<CreateSistemaCommand>(sistema)));
        }

        [HttpPut]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> PutSistema(SistemaResponse sistema)
        {
            return Ok(await _mediator.Send(_mapper.Map<UpdateSistemaCommand>(sistema)));
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> DeleteSistema(int id)
        {
            return Ok(await _mediator.Send(new DeleteSistemaCommand(id)));
        }

    }
}
