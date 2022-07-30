using SistemaSeguridad.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.IRepositories
{
    public interface IRepositorioRecurso
    {
        Task<List<Recurso>> GetAll(Expression<Func<Recurso, bool>> expr);
        Task<List<Recurso>> GetAllAsync();
        Task<Recurso> GetAsync(int id);
        Task<int> InsertAsync(Recurso recurso);
        Task UpdateAsync(Recurso recurso);
        Task DeleteAsync(Recurso recurso);
    }
}
