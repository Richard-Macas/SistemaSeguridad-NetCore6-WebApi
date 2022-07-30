using System;
using System.Collections.Generic;

namespace SistemaSeguridad.Entities.Entities
{
    public partial class Recurso
    {
        public Recurso()
        {
            RecursoPerfils = new HashSet<RecursoPerfil>();
            SistemaRecursos = new HashSet<SistemaRecurso>();
        }

        public int Id { get; set; }
        public int Nivel { get; set; }
        public string Descripcion { get; set; } = null!;
        public int? IdPadre { get; set; }
        public string URLPath { get; set; } = null!;
        public string? Icono { get; set; }
        public bool? EstaHabilitado { get; set; }

        public virtual ICollection<RecursoPerfil> RecursoPerfils { get; set; }
        public virtual ICollection<SistemaRecurso> SistemaRecursos { get; set; }
    }
}
