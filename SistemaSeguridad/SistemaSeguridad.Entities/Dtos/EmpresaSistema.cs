using System;
using System.Collections.Generic;

namespace SistemaSeguridad.Entities.Dtos
{
    public partial class EmpresaSistema
    {
        public int Id { get; set; }
        public int? IdSistema { get; set; }
        public int? IdEmpresa { get; set; }
        public bool? EstaHabilitado { get; set; }

        public Empresa? IdEmpresaNavigation { get; set; }
        public Sistema? IdSistemaNavigation { get; set; }
    }
}
