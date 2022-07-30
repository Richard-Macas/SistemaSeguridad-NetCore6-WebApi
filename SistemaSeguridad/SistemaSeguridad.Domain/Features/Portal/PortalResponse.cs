using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.Features.Portal
{
    public class PortalResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Responsable { get; set; } = null!;
        public string Dominio { get; set; } = null!;
        public bool? EstaHabilitado { get; set; }
    }
}
