using System;
using System.Collections.Generic;

namespace SistemaSeguridad.Entities.Entities
{
    public partial class Portal
    {
        public Portal()
        {
            Empresas = new HashSet<Empresa>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Responsable { get; set; } = null!;
        public string Dominio { get; set; } = null!;
        public bool? EstaHabilitado { get; set; }

        public virtual ICollection<Empresa> Empresas { get; set; }
    }
}
