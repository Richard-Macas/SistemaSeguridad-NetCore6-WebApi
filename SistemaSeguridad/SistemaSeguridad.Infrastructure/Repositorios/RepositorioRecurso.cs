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
    public class RepositorioRecurso : IRepositorioRecurso
    {
        private readonly IRepositorioGenerico<Recurso> _repositorio;

        public RepositorioRecurso(IRepositorioGenerico<Recurso> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<Recurso>> GetAll(Expression<Func<Recurso, bool>> expr)
        {
            return await _repositorio.Entities.Where(expr).ToListAsync();
        }

        public async Task<List<Recurso>> GetAllAsync()
        {
            return await _repositorio.GetAllAsync();
        }

        public async Task<Recurso> GetAsync(int id)
        {
            return await _repositorio.GetByIdAsync(id);
        }

        public async Task<int> InsertAsync(Recurso recurso)
        {
            await _repositorio.AddAsync(recurso);
            return recurso.Id;
        }

        public async Task UpdateAsync(Recurso recurso)
        {
            await _repositorio.UpdateAsync(recurso);
        }

        public async Task DeleteAsync(Recurso recurso)
        {
            await _repositorio.DeleteAsync(recurso);
        }
    }
}
