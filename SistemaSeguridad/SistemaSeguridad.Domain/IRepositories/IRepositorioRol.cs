using SistemaSeguridad.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.IRepositories
{
    public interface IRepositorioRol
    {
        Task<List<Rol>> GetAllAsync();
        Task<Rol> GetAsync(int id);
        Task<int> InsertAsync(Rol rol);
        Task UpdateAsync(Rol rol);
        Task DeleteAsync(Rol rol);
    }
}
