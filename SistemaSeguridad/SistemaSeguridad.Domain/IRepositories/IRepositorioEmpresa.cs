using SistemaSeguridad.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.IRepositories
{
    public interface IRepositorioEmpresa
    {
        Task<List<Empresa>> GetAllAsync();
        Task<Empresa> GetAsync(int id);
        Task<int> InsertAsync(Empresa empresa);
        Task UpdateAsync(Empresa empresa);
        Task DeleteAsync(Empresa empresa);
    }
}
