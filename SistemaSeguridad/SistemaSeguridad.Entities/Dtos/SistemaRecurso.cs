using System;
using System.Collections.Generic;

namespace SistemaSeguridad.Entities.Dtos
{
    public partial class SistemaRecurso
    {
        public int Id { get; set; }
        public int? IdSistema { get; set; }
        public int? IdRecurso { get; set; }

        public Recurso? IdRecursoNavigation { get; set; }
        public Sistema? IdSistemaNavigation { get; set; }
    }
}
