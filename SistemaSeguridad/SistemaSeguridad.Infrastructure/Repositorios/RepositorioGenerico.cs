using Microsoft.EntityFrameworkCore;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Repository.Persistencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Infrastructure.Repositorios
{
    public class RepositorioGenerico<T>: IRepositorioGenerico<T> where T : class
    {
        private readonly SistemaSeguridadDBContext _context;

        public RepositorioGenerico(SistemaSeguridadDBContext context)
        {
            _context = context;
        }

        public IQueryable<T> Entities => _context.Set<T>();

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }
        public Task UpdateAsync(T entity)
        {
            //_context.Entry(entity).CurrentValues.SetValues(entity);
            _context.Entry(entity).State = EntityState.Modified;

            return Task.CompletedTask;
        }

        public Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context
                .Set<T>()
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity =  await _context.Set<T>().FindAsync(id);
            
            if(entity != null)
                _context.Entry(entity).State = EntityState.Detached;

            return entity;
        }

    }
}
