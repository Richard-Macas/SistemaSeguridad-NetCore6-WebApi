using SistemaSeguridad.Entities.Dtos;
using dal = SistemaSeguridad.Entities.Entities;

namespace SistemaSeguridad.Entities.Mapper
{
    public class MapperPerfil
    {
        public MapperPerfil()
        {

        }

        public Perfil MapPerfil(dal.Perfil perfil)
        {
            return new Perfil
            {
                Id = perfil.Id,
                Nombre = perfil.Nombre,
            };
        }

        public dal.Perfil MapPerfil(Perfil perfil)
        {
            return new dal.Perfil
            {
                Id = perfil.Id,
                Nombre = perfil.Nombre,
            };
        }
    }
}
