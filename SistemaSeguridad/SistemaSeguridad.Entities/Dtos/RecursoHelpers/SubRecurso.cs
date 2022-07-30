using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Entities.Dtos.RecursoHelpers
{
    public class Subrecurso
    {
        public string Descripcion { get; set; } = null!;
        public string URLPath { get; set; } = null!;
        public string? Icono { get; set; }
    }
}
