using System;
using System.Collections.Generic;

namespace SistemaSeguridad.Entities.Entities
{
    public partial class RecursoPerfil
    {
        public int Id { get; set; }
        public int? IdRecurso { get; set; }
        public int? IdPerfil { get; set; }
        public int? IdRol { get; set; }
        public bool? EstaHabilitado { get; set; }

        public virtual Perfil? IdPerfilNavigation { get; set; }
        public virtual Recurso? IdRecursoNavigation { get; set; }
        public virtual Rol? IdRolNavigation { get; set; }
    }
}
