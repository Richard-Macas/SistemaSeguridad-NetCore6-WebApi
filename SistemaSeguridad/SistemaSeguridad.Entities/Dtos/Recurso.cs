using System;
using System.Collections.Generic;

namespace SistemaSeguridad.Entities.Dtos
{
    public partial class Recurso
    {
        public Recurso()
        {
            RecursoPerfils = new List<RecursoPerfil>();
            SistemaRecursos = new List<SistemaRecurso>();
        }

        public int Id { get; set; }
        public int Nivel { get; set; }
        public string Descripcion { get; set; } = null!;
        public int? IdPadre { get; set; }
        public string URLPath { get; set; } = null!;
        public string? Icono { get; set; }
        public bool? EstaHabilitado { get; set; }

        public List<RecursoPerfil> RecursoPerfils { get; set; }
        public List<SistemaRecurso> SistemaRecursos { get; set; }
    }
}
