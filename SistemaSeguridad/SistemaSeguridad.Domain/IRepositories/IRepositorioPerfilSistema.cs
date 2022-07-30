using SistemaSeguridad.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.IRepositories
{
    public interface IRepositorioPerfilSistema
    {
        Task<List<PerfilSistema>> GetAllAsync();
        Task<PerfilSistema> GetAsync(int id);
        Task<int> InsertAsync(PerfilSistema perfilSistema);
        Task UpdateAsync(PerfilSistema perfilSistema);
        Task DeleteAsync(PerfilSistema perfilSistema);
    }
}
