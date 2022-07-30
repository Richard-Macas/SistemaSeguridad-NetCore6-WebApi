using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.Features.Recursos
{
    public class RecursoResponse
    {
        public int Id { get; set; }
        public int Nivel { get; set; }
        public string Descripcion { get; set; } = null!;
        public int? IdPadre { get; set; }
        public string URLPath { get; set; } = null!;
        public string? Icono { get; set; }
        public bool? EstaHabilitado { get; set; }
    }
}
