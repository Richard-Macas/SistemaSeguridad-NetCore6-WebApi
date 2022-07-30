using System;
using System.Collections.Generic;

namespace SistemaSeguridad.Entities.Entities
{
    public partial class Rol
    {
        public Rol()
        {
            RecursoPerfils = new HashSet<RecursoPerfil>();
        }

        public int Id { get; set; }
        public bool? Create { get; set; }
        public bool? Read { get; set; }
        public bool? Update { get; set; }
        public bool? Delete { get; set; }

        public virtual ICollection<RecursoPerfil> RecursoPerfils { get; set; }
    }
}
