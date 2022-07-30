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
    public class RepositorioRol : IRepositorioRol
    {
        private readonly IRepositorioGenerico<Rol> _repositorio;

        public RepositorioRol(IRepositorioGenerico<Rol> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<Rol>> GetAllAsync()
        {
            return await _repositorio.GetAllAsync();
        }

        public async Task<Rol> GetAsync(int id)
        {
            return await _repositorio.GetByIdAsync(id);
        }

        public async Task<int> InsertAsync(Rol rol)
        {
            await _repositorio.AddAsync(rol);
            return rol.Id;
        }

        public async Task UpdateAsync(Rol rol)
        {
            await _repositorio.UpdateAsync(rol);
        }

        public async Task DeleteAsync(Rol rol)
        {
            await _repositorio.DeleteAsync(rol);
        }
    }
}
