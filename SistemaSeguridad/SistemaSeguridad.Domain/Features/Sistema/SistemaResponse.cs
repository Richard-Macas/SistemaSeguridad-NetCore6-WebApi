using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.Features.Sistema
{
    public class SistemaResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Dominio { get; set; } = null!;
        public string? Subdominio { get; set; }
        public bool? EstaHabilitado { get; set; }
    }
}
