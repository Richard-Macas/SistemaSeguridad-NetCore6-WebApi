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
    public class RepositorioPerfilSistema : IRepositorioPerfilSistema
    {
        private readonly IRepositorioGenerico<PerfilSistema> _repositorio;

        public RepositorioPerfilSistema(IRepositorioGenerico<PerfilSistema> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<PerfilSistema>> GetAllAsync()
        {
            return await _repositorio.GetAllAsync();
        }

        public async Task<PerfilSistema> GetAsync(int id)
        {
            return await _repositorio.GetByIdAsync(id);
        }

        public async Task<int> InsertAsync(PerfilSistema perfilSistema)
        {
            await _repositorio.AddAsync(perfilSistema);
            return perfilSistema.Id;
        }

        public async Task UpdateAsync(PerfilSistema perfilSistema)
        {
            await _repositorio.UpdateAsync(perfilSistema);
        }

        public async Task DeleteAsync(PerfilSistema perfilSistema)
        {
            await _repositorio.DeleteAsync(perfilSistema);
        }
    }
}
