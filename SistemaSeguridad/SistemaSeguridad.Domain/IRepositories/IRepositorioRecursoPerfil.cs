using SistemaSeguridad.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.IRepositories
{
    public interface IRepositorioRecursoPerfil
    {
        Task<List<RecursoPerfil>> GetAllAsync();
        Task<RecursoPerfil> GetAsync(int id);
        Task<int> InsertAsync(RecursoPerfil recursoPerfil);
        Task UpdateAsync(RecursoPerfil recursoPerfil);
        Task DeleteAsync(RecursoPerfil recursoPerfil);
    }
}
