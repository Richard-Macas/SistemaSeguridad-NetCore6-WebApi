using SistemaSeguridad.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.IRepositories
{
    public interface IRepositorioSistemaRecurso
    {
        Task<List<SistemaRecurso>> GetAllAsync();
        Task<SistemaRecurso> GetAsync(int id);
        Task<int> InsertAsync(SistemaRecurso sistemaRecurso);
        Task UpdateAsync(SistemaRecurso sistemaRecurso);
        Task DeleteAsync(SistemaRecurso sistemaRecurso);
    }
}
