using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaSeguridad.API.Mapping;
using SistemaSeguridad.Domain.Features.Portal;
using SistemaSeguridad.Domain.Features.Portal.Commands.Create;
using SistemaSeguridad.Domain.Features.Portal.Commands.Delete;
using SistemaSeguridad.Domain.Features.Portal.Commands.Update;
using SistemaSeguridad.Domain.Features.Portal.Queries.GetAll;
using SistemaSeguridad.Domain.Features.Portal.Queries.GetById;

namespace SistemaSeguridad.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PortalController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public PortalController(IMediator mediator)
        {
            _mediator = mediator;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        [HttpGet]
        public async Task<IActionResult> GetPortals()
        {
            return Ok(await _mediator.Send(new GetAllPortalQuery()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPortal(int id)
        {
            return Ok(await _mediator.Send(new GetPortalByIdQuery(id)));
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> PostPortal(PortalResponse portal)
        {
            return Ok(await _mediator.Send(_mapper.Map<CreatePortalCommand>(portal)));
        }

        [HttpPut]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> PutPortal(PortalResponse portal)
        {
            return Ok(await _mediator.Send(_mapper.Map<UpdatePortalCommand>(portal)));
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> DeletePortal(int id)
        {
            return Ok(await _mediator.Send(new DeletePortalCommand(id)));
        }

    }
}
