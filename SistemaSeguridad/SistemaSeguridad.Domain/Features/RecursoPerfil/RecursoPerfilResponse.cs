using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.Features.RecursoPerfil
{
    public class RecursoPerfilResponse
    {
        public int Id { get; set; }
        public int? IdRecurso { get; set; }
        public int? IdPerfil { get; set; }
        public int? IdRol { get; set; }
        public bool? EstaHabilitado { get; set; }
    }
}
