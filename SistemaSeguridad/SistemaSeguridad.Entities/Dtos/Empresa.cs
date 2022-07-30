using System;
using System.Collections.Generic;

namespace SistemaSeguridad.Entities.Dtos
{
    public partial class Empresa
    {
        public Empresa()
        {
            EmpresaSistemas = new List<EmpresaSistema>();
        }

        public int Id { get; set; }
        public int? IdPortal { get; set; }
        public string Empresa1 { get; set; } = null!;
        public string? CorreoAdministrador { get; set; }
        public string? TelefonoAdministrador { get; set; }
        public string Dominio { get; set; } = null!;
        public bool? EstaHabilitado { get; set; }

        public Portal? IdPortalNavigation { get; set; }
        public List<EmpresaSistema> EmpresaSistemas { get; set; }
    }
}
