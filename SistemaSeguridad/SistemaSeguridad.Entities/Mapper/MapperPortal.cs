using SistemaSeguridad.Entities.Dtos;
using dal = SistemaSeguridad.Entities.Entities;

namespace SistemaSeguridad.Entities.Mapper
{
    public class MapperPortal
    {
        public MapperPortal()
        {

        }

        public Portal MapPortal(dal.Portal portal)
        {
            return new Portal
            {
                Id = portal.Id,
                Nombre = portal.Nombre,
                Responsable = portal.Responsable,
                Dominio = portal.Dominio,
                EstaHabilitado = portal.EstaHabilitado,
            };
        }

        public dal.Portal MapPortal(Portal portal)
        {
            return new dal.Portal
            {
                Id = portal.Id,
                Nombre = portal.Nombre,
                Responsable = portal.Responsable,
                Dominio = portal.Dominio,
                EstaHabilitado = portal.EstaHabilitado,
            };
        }
    }
}
