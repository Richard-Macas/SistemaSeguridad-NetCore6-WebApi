using Microsoft.EntityFrameworkCore;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Infrastructure.Repositorios
{
    public class RepositorioSistema : IRepositorioSistema
    {
        private readonly IRepositorioGenerico<Sistema> _repositorio;

        public RepositorioSistema(IRepositorioGenerico<Sistema> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<Sistema>> GetAll(Expression<Func<Sistema, bool>> expr)
        {
            return await _repositorio.Entities.Where(expr).ToListAsync();
        }

        public async Task<Sistema> Get(Expression<Func<Sistema, bool>> expr)
        {
            return await _repositorio.Entities.FirstOrDefaultAsync(expr);
        }

        public async Task<List<Sistema>> GetAllAsync()
        {
            return await _repositorio.GetAllAsync();
        }

        public async Task<Sistema> GetAsync(int id)
        {
            return await _repositorio.GetByIdAsync(id);
        }

        public async Task<int> InsertAsync(Sistema sistema)
        {
            await _repositorio.AddAsync(sistema);
            return sistema.Id;
        }

        public async Task UpdateAsync(Sistema sistema)
        {
            await _repositorio.UpdateAsync(sistema);
        }

        public async Task DeleteAsync(Sistema sistema)
        {
            await _repositorio.DeleteAsync(sistema);
        }
    }
}
