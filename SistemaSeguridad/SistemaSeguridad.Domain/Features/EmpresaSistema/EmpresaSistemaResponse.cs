using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.Features.EmpresaSistema
{
    public class EmpresaSistemaResponse
    {
        public int Id { get; set; }
        public int? IdSistema { get; set; }
        public int? IdEmpresa { get; set; }
        public bool? EstaHabilitado { get; set; }
    }
}
