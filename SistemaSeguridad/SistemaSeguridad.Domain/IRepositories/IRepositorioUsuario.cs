using SistemaSeguridad.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.IRepositories
{
    public interface IRepositorioUsuario
    {
        Task<Usuario> Get(Expression<Func<Usuario, bool>> expr);
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario> GetAsync(int id);
        Task<int> InsertAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(Usuario usuario);
    }
}
