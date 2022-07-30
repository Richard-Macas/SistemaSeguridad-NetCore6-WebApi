using System;
using System.Collections.Generic;

namespace SistemaSeguridad.Entities.Entities
{
    public partial class EmpresaSistema
    {
        public int Id { get; set; }
        public int? IdSistema { get; set; }
        public int? IdEmpresa { get; set; }
        public bool? EstaHabilitado { get; set; }

        public virtual Empresa? IdEmpresaNavigation { get; set; }
        public virtual Sistema? IdSistemaNavigation { get; set; }
    }
}
