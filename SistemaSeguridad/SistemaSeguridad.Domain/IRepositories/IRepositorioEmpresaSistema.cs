using SistemaSeguridad.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.IRepositories
{
    public interface IRepositorioEmpresaSistema
    {
        Task<List<EmpresaSistema>> GetAllAsync();
        Task<EmpresaSistema> GetAsync(int id);
        Task<int> InsertAsync(EmpresaSistema empresaSistema);
        Task UpdateAsync(EmpresaSistema empresaSistema);
        Task DeleteAsync(EmpresaSistema empresaSistema);
    }
}
