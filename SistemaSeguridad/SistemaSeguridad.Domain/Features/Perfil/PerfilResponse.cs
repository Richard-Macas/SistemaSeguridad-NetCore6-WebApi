using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.Features.Perfil
{
    public class PerfilResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
    }
}
