using System;
using System.Collections.Generic;

namespace SistemaSeguridad.Entities.Dtos
{
    public partial class Portal
    {
        public Portal()
        {
            Empresas = new List<Empresa>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Responsable { get; set; } = null!;
        public string Dominio { get; set; } = null!;
        public bool? EstaHabilitado { get; set; }

        public List<Empresa> Empresas { get; set; }
    }
}
