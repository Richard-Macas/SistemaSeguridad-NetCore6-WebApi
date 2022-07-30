using SistemaSeguridad.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using dal = SistemaSeguridad.Entities.Entities;

namespace SistemaSeguridad.Entities.Mapper
{
    public class MapperUsuario
    {
        public MapperUsuario()
        {

        }

        public Usuario MapUsuario(dal.Usuario usuario)
        {
            return new Usuario
            {
                Id = usuario.Id,
                Username = usuario.Username,
                Password = usuario.Password,
                UsuarioPerfils = usuario.UsuarioPerfils.Select(usuarioUsuarioPerfil => new UsuarioPerfil
                {
                    Id = usuarioUsuarioPerfil.Id,
                    IdUsuario = usuarioUsuarioPerfil.IdUsuario,
                    IdPerfil = usuarioUsuarioPerfil.IdPerfil,
                    IdPerfilNavigation = usuarioUsuarioPerfil.IdPerfilNavigation != null ? new Perfil
                    {
                        Id = usuarioUsuarioPerfil.IdPerfilNavigation.Id,
                        Nombre = usuarioUsuarioPerfil.IdPerfilNavigation.Nombre,
                    } : null,
                }).ToList()
            };
        }

        public dal.Usuario MapUsuario(Usuario usuario)
        {
            return new dal.Usuario
            {
                Id = usuario.Id,
                Username = usuario.Username,
                Password = usuario.Password,
            };
        }
    }
}
