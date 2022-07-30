using FluentValidation;
using SistemaSeguridad.Domain.Features.Login;
using SistemaSeguridad.Domain.Features.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.ValidationResponse
{
    public class SistemaResponseValidation : AbstractValidator<SistemaResponse>
    {
        public SistemaResponseValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Nombre).NotEmpty().NotNull();
            RuleFor(x => x.Dominio).NotEmpty().NotNull();

        }
    }
}
