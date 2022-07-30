using SistemaSeguridad.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.IRepositories
{
    public interface IRepositorioUsuarioPerfil
    {
        Task<List<UsuarioPerfil>> GetAllAsync();
        Task<UsuarioPerfil> GetAsync(int id);
        Task<int> InsertAsync(UsuarioPerfil usuarioPerfil);
        Task UpdateAsync(UsuarioPerfil usuarioPerfil);
        Task DeleteAsync(UsuarioPerfil usuarioPerfil);
    }
}
