using System;
using System.Collections.Generic;

namespace SistemaSeguridad.Entities.Dtos
{
    public partial class Sistema
    {
        public Sistema()
        {
            EmpresaSistemas = new List<EmpresaSistema>();
            PerfilSistemas = new List<PerfilSistema>();
            SistemaRecursos = new List<SistemaRecurso>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Dominio { get; set; } = null!;
        public string? Subdominio { get; set; }
        public bool? EstaHabilitado { get; set; }

        public List<EmpresaSistema> EmpresaSistemas { get; set; }
        public List<PerfilSistema> PerfilSistemas { get; set; }
        public List<SistemaRecurso> SistemaRecursos { get; set; }
    }
}
