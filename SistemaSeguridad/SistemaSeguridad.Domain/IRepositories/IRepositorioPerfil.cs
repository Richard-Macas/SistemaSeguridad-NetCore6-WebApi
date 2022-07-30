using SistemaSeguridad.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.IRepositories
{
    public interface IRepositorioPerfil
    {
        Task<List<Perfil>> GetAllAsync();
        Task<Perfil> GetAsync(int id);
        Task<int> InsertAsync(Perfil perfil);
        Task UpdateAsync(Perfil perfil);
        Task DeleteAsync(Perfil perfil);
    }
}
