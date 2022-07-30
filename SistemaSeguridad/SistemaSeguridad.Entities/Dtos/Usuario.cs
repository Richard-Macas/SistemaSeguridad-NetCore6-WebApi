using System;
using System.Collections.Generic;

namespace SistemaSeguridad.Entities.Dtos
{
    public partial class Usuario
    {
        public Usuario()
        {
            UsuarioPerfils = new List<UsuarioPerfil>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public List<UsuarioPerfil> UsuarioPerfils { get; set; }
    }
}
