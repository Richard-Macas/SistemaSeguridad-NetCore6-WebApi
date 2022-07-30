using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaSeguridad.API.Mapping;
using SistemaSeguridad.Domain.Features.EmpresaSistema;
using SistemaSeguridad.Domain.Features.EmpresaSistema.Commands.Create;
using SistemaSeguridad.Domain.Features.EmpresaSistema.Commands.Delete;
using SistemaSeguridad.Domain.Features.EmpresaSistema.Commands.Update;
using SistemaSeguridad.Domain.Features.EmpresaSistema.Queries.GetAll;
using SistemaSeguridad.Domain.Features.EmpresaSistema.Queries.GetById;

namespace SistemaSeguridad.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaSistemaController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public EmpresaSistemaController(IMediator mediator)
        {
            _mediator = mediator;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        [HttpGet]
        public async Task<IActionResult> GetEmpresaSistemas()
        {
            return Ok(await _mediator.Send(new GetAllEmpresaSistemaQuery()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmpresaSistema(int id)
        {
            return Ok(await _mediator.Send(new GetEmpresaSistemaByIdQuery(id)));
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> PostEmpresaSistema(EmpresaSistemaResponse empresaSistema)
        {
            return Ok(await _mediator.Send(_mapper.Map<CreateEmpresaSistemaCommand>(empresaSistema)));
        }

        [HttpPut]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> PutEmpresaSistema(EmpresaSistemaResponse empresaSistema)
        {
            return Ok(await _mediator.Send(_mapper.Map<UpdateEmpresaSistemaCommand>(empresaSistema)));
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> DeleteEmpresaSistema(int id)
        {
            return Ok(await _mediator.Send(new DeleteEmpresaSistemaCommand(id)));
        }

    }
}
