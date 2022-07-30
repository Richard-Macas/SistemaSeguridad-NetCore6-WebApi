using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.Features.PerfilSistema
{
    public class PerfilSistemaResponse
    {
        public int Id { get; set; }
        public int? IdSistema { get; set; }
        public int? IdPerfil { get; set; }
        public bool? EstaHabilitado { get; set; }
    }
}
