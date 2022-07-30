using System;
using System.Collections.Generic;

namespace SistemaSeguridad.Entities.Entities
{
    public partial class Empresa
    {
        public Empresa()
        {
            EmpresaSistemas = new HashSet<EmpresaSistema>();
        }

        public int Id { get; set; }
        public int? IdPortal { get; set; }
        public string Empresa1 { get; set; } = null!;
        public string? CorreoAdministrador { get; set; }
        public string? TelefonoAdministrador { get; set; }
        public string Dominio { get; set; } = null!;
        public bool? EstaHabilitado { get; set; }

        public virtual Portal? IdPortalNavigation { get; set; }
        public virtual ICollection<EmpresaSistema> EmpresaSistemas { get; set; }
    }
}
