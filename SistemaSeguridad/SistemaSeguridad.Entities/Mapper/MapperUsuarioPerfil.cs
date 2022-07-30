using SistemaSeguridad.Entities.Dtos;
using dal = SistemaSeguridad.Entities.Entities;

namespace SistemaSeguridad.Entities.Mapper
{
    public class MapperUsuarioPerfil
    {
        public MapperUsuarioPerfil()
        {

        }

        public UsuarioPerfil MapUsuarioPerfil(dal.UsuarioPerfil usuarioPerfil)
        {
            return new UsuarioPerfil
            {
                Id = usuarioPerfil.Id,
                IdUsuario = usuarioPerfil.IdUsuario,
                IdPerfil = usuarioPerfil.IdPerfil,
            };
        }

        public dal.UsuarioPerfil MapUsuarioPerfil(UsuarioPerfil usuarioPerfil)
        {
            return new dal.UsuarioPerfil
            {
                Id = usuarioPerfil.Id,
                IdUsuario = usuarioPerfil.IdUsuario,
                IdPerfil = usuarioPerfil.IdPerfil,
            };
        }
    }
}
