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
    public class RepositorioRecursoPerfil : IRepositorioRecursoPerfil
    {
        private readonly IRepositorioGenerico<RecursoPerfil> _repositorio;

        public RepositorioRecursoPerfil(IRepositorioGenerico<RecursoPerfil> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<RecursoPerfil>> GetAllAsync()
        {
            return await _repositorio.GetAllAsync();
        }

        public async Task<RecursoPerfil> GetAsync(int id)
        {
            return await _repositorio.GetByIdAsync(id);
        }

        public async Task<int> InsertAsync(RecursoPerfil recursoPerfil)
        {
            await _repositorio.AddAsync(recursoPerfil);
            return recursoPerfil.Id;
        }

        public async Task UpdateAsync(RecursoPerfil recursoPerfil)
        {
            await _repositorio.UpdateAsync(recursoPerfil);
        }

        public async Task DeleteAsync(RecursoPerfil recursoPerfil)
        {
            await _repositorio.DeleteAsync(recursoPerfil);
        }
    }
}
