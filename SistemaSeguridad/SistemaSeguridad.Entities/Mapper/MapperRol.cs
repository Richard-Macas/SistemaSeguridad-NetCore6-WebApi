using SistemaSeguridad.Entities.Dtos;
using dal = SistemaSeguridad.Entities.Entities;

namespace SistemaSeguridad.Entities.Mapper
{
    public class MapperRol
    {
        public MapperRol()
        {

        }

        public Rol MapRol(dal.Rol rol)
        {
            return new Rol
            {
                Id = rol.Id,
                Create = rol.Create,
                Read = rol.Read,
                Update = rol.Update,
                Delete = rol.Delete,
            };
        }

        public dal.Rol MapRol(Rol rol)
        {
            return new dal.Rol
            {
                Id = rol.Id,
                Create = rol.Create,
                Read = rol.Read,
                Update = rol.Update,
                Delete = rol.Delete,
            };
        }
    }
}
