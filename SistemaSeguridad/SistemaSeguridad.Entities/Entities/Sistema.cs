using System;
using System.Collections.Generic;

namespace SistemaSeguridad.Entities.Entities
{
    public partial class Sistema
    {
        public Sistema()
        {
            EmpresaSistemas = new HashSet<EmpresaSistema>();
            PerfilSistemas = new HashSet<PerfilSistema>();
            SistemaRecursos = new HashSet<SistemaRecurso>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Dominio { get; set; } = null!;
        public string? Subdominio { get; set; }
        public bool? EstaHabilitado { get; set; }

        public virtual ICollection<EmpresaSistema> EmpresaSistemas { get; set; }
        public virtual ICollection<PerfilSistema> PerfilSistemas { get; set; }
        public virtual ICollection<SistemaRecurso> SistemaRecursos { get; set; }
    }
}
