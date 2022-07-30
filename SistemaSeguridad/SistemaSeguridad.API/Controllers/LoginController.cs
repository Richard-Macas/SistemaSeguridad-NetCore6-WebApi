using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaSeguridad.API.Mapping;
using SistemaSeguridad.Domain.Features.Login;
using SistemaSeguridad.Domain.Features.Login.Queries.GetByExpression;

namespace SistemaSeguridad.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginResponse login)
        {
            return Ok(await _mediator.Send(_mapper.Map<GetLoginTokenByExpressionQuery>(login)));
        }

    }
}
