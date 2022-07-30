using System;
using System.Collections.Generic;

namespace SistemaSeguridad.Entities.Entities
{
    public partial class Perfil
    {
        public Perfil()
        {
            PerfilSistemas = new HashSet<PerfilSistema>();
            RecursoPerfils = new HashSet<RecursoPerfil>();
            UsuarioPerfils = new HashSet<UsuarioPerfil>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<PerfilSistema> PerfilSistemas { get; set; }
        public virtual ICollection<RecursoPerfil> RecursoPerfils { get; set; }
        public virtual ICollection<UsuarioPerfil> UsuarioPerfils { get; set; }
    }
}
