using System;
using System.Collections.Generic;

namespace SistemaSeguridad.Entities.Dtos
{
    public partial class Rol
    {
        public Rol()
        {
            RecursoPerfils = new List<RecursoPerfil>();
        }

        public int Id { get; set; }
        public bool? Create { get; set; }
        public bool? Read { get; set; }
        public bool? Update { get; set; }
        public bool? Delete { get; set; }

        public List<RecursoPerfil> RecursoPerfils { get; set; }
    }
}
