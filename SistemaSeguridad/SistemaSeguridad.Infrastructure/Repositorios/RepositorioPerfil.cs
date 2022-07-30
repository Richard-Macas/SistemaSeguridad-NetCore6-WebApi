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
    public class RepositorioPerfil : IRepositorioPerfil
    {
        private readonly IRepositorioGenerico<Perfil> _repositorio;

        public RepositorioPerfil(IRepositorioGenerico<Perfil> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<Perfil>> GetAllAsync()
        {
            return await _repositorio.GetAllAsync();
        }

        public async Task<Perfil> GetAsync(int id)
        {
            return await _repositorio.GetByIdAsync(id);
        }

        public async Task<int> InsertAsync(Perfil perfil)
        {
            await _repositorio.AddAsync(perfil);
            return perfil.Id;
        }

        public async Task UpdateAsync(Perfil perfil)
        {
            await _repositorio.UpdateAsync(perfil);
        }

        public async Task DeleteAsync(Perfil perfil)
        {
            await _repositorio.DeleteAsync(perfil);
        }
    }
}
