using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.Features.Empresa
{
    public class EmpresaResponse
    {
        public int Id { get; set; }
        public int? IdPortal { get; set; }
        public string Empresa1 { get; set; } = null!;
        public string? CorreoAdministrador { get; set; }
        public string? TelefonoAdministrador { get; set; }
        public string Dominio { get; set; } = null!;
        public bool? EstaHabilitado { get; set; }
    }
}
