using System;
using System.Collections.Generic;

namespace SistemaSeguridad.Entities.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            UsuarioPerfils = new HashSet<UsuarioPerfil>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<UsuarioPerfil> UsuarioPerfils { get; set; }
    }
}
