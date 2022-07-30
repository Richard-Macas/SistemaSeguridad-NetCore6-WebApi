using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaSeguridad.API.Mapping;
using SistemaSeguridad.Domain.Features.Empresa;
using SistemaSeguridad.Domain.Features.Empresa.Commands.Create;
using SistemaSeguridad.Domain.Features.Empresa.Commands.Delete;
using SistemaSeguridad.Domain.Features.Empresa.Commands.Update;
using SistemaSeguridad.Domain.Features.Empresa.Queries.GetAll;
using SistemaSeguridad.Domain.Features.Empresa.Queries.GetById;

namespace SistemaSeguridad.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public EmpresaController(IMediator mediator)
        {
            _mediator = mediator;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        [HttpGet]
        public async Task<IActionResult> GetEmpresas()
        {
            return Ok(await _mediator.Send(new GetAllEmpresaQuery()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmpresa(int id)
        {
            return Ok(await _mediator.Send(new GetEmpresaByIdQuery(id)));
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> PostEmpresa(EmpresaResponse empresa)
        {
            return Ok(await _mediator.Send(_mapper.Map<CreateEmpresaCommand>(empresa)));
        }

        [HttpPut]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> PutEmpresa(EmpresaResponse empresa)
        {
            return Ok(await _mediator.Send(_mapper.Map<UpdateEmpresaCommand>(empresa)));
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> DeleteEmpresa(int id)
        {
            return Ok(await _mediator.Send(new DeleteEmpresaCommand(id)));
        }

    }
}
