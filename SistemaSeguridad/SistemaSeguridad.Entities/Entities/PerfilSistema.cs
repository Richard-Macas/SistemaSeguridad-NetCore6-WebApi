using System;
using System.Collections.Generic;

namespace SistemaSeguridad.Entities.Entities
{
    public partial class PerfilSistema
    {
        public int Id { get; set; }
        public int? IdSistema { get; set; }
        public int? IdPerfil { get; set; }
        public bool? EstaHabilitado { get; set; }

        public virtual Perfil? IdPerfilNavigation { get; set; }
        public virtual Sistema? IdSistemaNavigation { get; set; }
    }
}
