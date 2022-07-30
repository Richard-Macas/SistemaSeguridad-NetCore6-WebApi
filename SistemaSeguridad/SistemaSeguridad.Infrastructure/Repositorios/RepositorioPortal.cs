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
    public class RepositorioPortal : IRepositorioPortal
    {
        private readonly IRepositorioGenerico<Portal> _repositorio;

        public RepositorioPortal(IRepositorioGenerico<Portal> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<Portal>> GetAllAsync()
        {
            return await _repositorio.GetAllAsync();
        }

        public async Task<Portal> GetAsync(int id)
        {
            return await _repositorio.GetByIdAsync(id);
        }

        public async Task<int> InsertAsync(Portal portal)
        {
            await _repositorio.AddAsync(portal);
            return portal.Id;
        }

        public async Task UpdateAsync(Portal portal)
        {
            await _repositorio.UpdateAsync(portal);
        }

        public async Task DeleteAsync(Portal portal)
        {
            await _repositorio.DeleteAsync(portal);
        }
    }
}
