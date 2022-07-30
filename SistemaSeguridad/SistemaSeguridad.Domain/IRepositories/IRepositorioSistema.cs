using SistemaSeguridad.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.IRepositories
{
    public interface IRepositorioSistema
    {
        Task<List<Sistema>> GetAll(Expression<Func<Sistema, bool>> expr);
        Task<Sistema> Get(Expression<Func<Sistema, bool>> expr);
        Task<List<Sistema>> GetAllAsync();
        Task<Sistema> GetAsync(int id);
        Task<int> InsertAsync(Sistema sistema);
        Task UpdateAsync(Sistema sistema);
        Task DeleteAsync(Sistema sistema);


    }
}
