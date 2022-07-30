using FluentValidation;
using SistemaSeguridad.Domain.Features.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.ValidationResponse
{
    public class LoginResponseValidation : AbstractValidator<LoginResponse>
    {
        public LoginResponseValidation()
        {
            RuleFor(x => x.Username).NotEmpty().NotNull();
            RuleFor(x => x.Password).NotEmpty().NotNull();
        }
    }
}
