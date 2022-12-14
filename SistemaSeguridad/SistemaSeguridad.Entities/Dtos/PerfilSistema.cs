using System;
using System.Collections.Generic;

namespace SistemaSeguridad.Entities.Dtos
{
    public partial class PerfilSistema
    {
        public int Id { get; set; }
        public int? IdSistema { get; set; }
        public int? IdPerfil { get; set; }
        public bool? EstaHabilitado { get; set; }

        public Perfil? IdPerfilNavigation { get; set; }
        public Sistema? IdSistemaNavigation { get; set; }
    }
}
