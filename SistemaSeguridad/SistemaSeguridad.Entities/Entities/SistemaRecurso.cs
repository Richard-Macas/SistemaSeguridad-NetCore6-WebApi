using System;
using System.Collections.Generic;

namespace SistemaSeguridad.Entities.Entities
{
    public partial class SistemaRecurso
    {
        public int Id { get; set; }
        public int? IdSistema { get; set; }
        public int? IdRecurso { get; set; }

        public virtual Recurso? IdRecursoNavigation { get; set; }
        public virtual Sistema? IdSistemaNavigation { get; set; }
    }
}
