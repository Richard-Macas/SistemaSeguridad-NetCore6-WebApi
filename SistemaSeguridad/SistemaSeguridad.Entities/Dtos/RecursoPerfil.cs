using System;
using System.Collections.Generic;

namespace SistemaSeguridad.Entities.Dtos
{
    public partial class RecursoPerfil
    {
        public int Id { get; set; }
        public int? IdRecurso { get; set; }
        public int? IdPerfil { get; set; }
        public int? IdRol { get; set; }
        public bool? EstaHabilitado { get; set; }

        public Perfil? IdPerfilNavigation { get; set; }
        public Recurso? IdRecursoNavigation { get; set; }
        public Rol? IdRolNavigation { get; set; }
    }
}
