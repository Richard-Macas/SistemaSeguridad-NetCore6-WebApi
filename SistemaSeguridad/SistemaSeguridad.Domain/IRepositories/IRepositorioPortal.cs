using SistemaSeguridad.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.IRepositories
{
    public interface IRepositorioPortal
    {
        Task<List<Portal>> GetAllAsync();
        Task<Portal> GetAsync(int id);
        Task<int> InsertAsync(Portal portal);
        Task UpdateAsync(Portal portal);
        Task DeleteAsync(Portal portal);
    }
}
