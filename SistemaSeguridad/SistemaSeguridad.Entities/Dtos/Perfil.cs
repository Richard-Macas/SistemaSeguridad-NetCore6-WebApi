using System;
using System.Collections.Generic;

namespace SistemaSeguridad.Entities.Dtos
{
    public partial class Perfil
    {
        public Perfil()
        {
            PerfilSistemas = new List<PerfilSistema>();
            RecursoPerfils = new List<RecursoPerfil>();
            UsuarioPerfils = new List<UsuarioPerfil>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public List<PerfilSistema> PerfilSistemas { get; set; }
        public List<RecursoPerfil> RecursoPerfils { get; set; }
        public List<UsuarioPerfil> UsuarioPerfils { get; set; }
    }
}
