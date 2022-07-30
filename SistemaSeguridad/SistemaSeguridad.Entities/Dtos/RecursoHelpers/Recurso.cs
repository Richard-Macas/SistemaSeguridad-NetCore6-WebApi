using System;
using System.Collections.Generic;

namespace SistemaSeguridad.Entities.Dtos.RecursoHelpers
{
    public partial class RecursoPadre
    {
        public RecursoPadre()
        {
            Subrecursos = new List<Subrecurso>();
        }

        public string Descripcion { get; set; } = null!;
        public string URLPath { get; set; } = null!;
        public string? Icono { get; set; }

        public List<Subrecurso> Subrecursos { get; set; }
    }
}
