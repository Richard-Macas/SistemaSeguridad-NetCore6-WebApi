using System;
using System.Collections.Generic;

namespace SistemaSeguridad.Entities.Dtos
{
    public partial class UsuarioPerfil
    {
        public int Id { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdPerfil { get; set; }

        public Perfil? IdPerfilNavigation { get; set; }
        public Usuario? IdUsuarioNavigation { get; set; }
    }
}
