using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.Features.SistemaRecurso
{
    public class SistemaRecursoResponse
    {
        public int Id { get; set; }
        public int? IdSistema { get; set; }
        public int? IdRecurso { get; set; }
    }
}
