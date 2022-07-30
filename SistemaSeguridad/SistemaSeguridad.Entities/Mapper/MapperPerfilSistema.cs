using SistemaSeguridad.Entities.Dtos;
using dal = SistemaSeguridad.Entities.Entities;

namespace SistemaSeguridad.Entities.Mapper
{
    public class MapperPerfilSistema
    {
        public MapperPerfilSistema()
        {

        }

        public PerfilSistema MapPerfilSistema(dal.PerfilSistema perfilSistema)
        {
            return new PerfilSistema
            {
                Id = perfilSistema.Id,
                IdSistema = perfilSistema.IdSistema,
                IdPerfil = perfilSistema.IdPerfil,
                EstaHabilitado = perfilSistema.EstaHabilitado,
            };
        }

        public dal.PerfilSistema MapPerfilSistema(PerfilSistema perfilSistema)
        {
            return new dal.PerfilSistema
            {
                Id = perfilSistema.Id,
                IdSistema = perfilSistema.IdSistema,
                IdPerfil = perfilSistema.IdPerfil,
                EstaHabilitado = perfilSistema.EstaHabilitado,
            };
        }
    }
}
