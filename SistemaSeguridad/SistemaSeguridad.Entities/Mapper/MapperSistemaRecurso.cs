using SistemaSeguridad.Entities.Dtos;
using dal = SistemaSeguridad.Entities.Entities;

namespace SistemaSeguridad.Entities.Mapper
{
    public class MapperSistemaRecurso
    {
        public MapperSistemaRecurso()
        {

        }

        public SistemaRecurso MapSistemaRecurso(dal.SistemaRecurso sistemaRecurso)
        {
            return new SistemaRecurso
            {
                Id = sistemaRecurso.Id,
                IdSistema = sistemaRecurso.IdSistema,
                IdRecurso = sistemaRecurso.IdRecurso,
            };
        }

        public dal.SistemaRecurso MapSistemaRecurso(SistemaRecurso sistemaRecurso)
        {
            return new dal.SistemaRecurso
            {
                Id = sistemaRecurso.Id,
                IdSistema = sistemaRecurso.IdSistema,
                IdRecurso = sistemaRecurso.IdRecurso,
            };
        }
    }
}
