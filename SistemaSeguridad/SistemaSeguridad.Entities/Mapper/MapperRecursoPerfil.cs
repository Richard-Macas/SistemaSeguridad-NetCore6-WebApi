using SistemaSeguridad.Entities.Dtos;
using dal = SistemaSeguridad.Entities.Entities;

namespace SistemaSeguridad.Entities.Mapper
{
    public class MapperRecursoPerfil
    {
        public MapperRecursoPerfil()
        {

        }

        public RecursoPerfil MapRecursoPerfil(dal.RecursoPerfil recursoPerfil)
        {
            return new RecursoPerfil
            {
                Id = recursoPerfil.Id,
                IdRecurso = recursoPerfil.IdRecurso,
                IdPerfil = recursoPerfil.IdPerfil,
                IdRol = recursoPerfil.IdRol,
                EstaHabilitado = recursoPerfil.EstaHabilitado,
            };
        }

        public dal.RecursoPerfil MapRecursoPerfil(RecursoPerfil recursoPerfil)
        {
            return new dal.RecursoPerfil
            {
                Id = recursoPerfil.Id,
                IdRecurso = recursoPerfil.IdRecurso,
                IdPerfil = recursoPerfil.IdPerfil,
                IdRol = recursoPerfil.IdRol,
                EstaHabilitado = recursoPerfil.EstaHabilitado,
            };
        }
    }
}
