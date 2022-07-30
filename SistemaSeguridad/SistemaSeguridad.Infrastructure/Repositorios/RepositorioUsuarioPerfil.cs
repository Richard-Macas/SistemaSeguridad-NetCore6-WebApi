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
    public class RepositorioUsuarioPerfil : IRepositorioUsuarioPerfil
    {
        private readonly IRepositorioGenerico<UsuarioPerfil> _repositorio;

        public RepositorioUsuarioPerfil(IRepositorioGenerico<UsuarioPerfil> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<UsuarioPerfil>> GetAllAsync()
        {
            return await _repositorio.GetAllAsync();
        }

        public async Task<UsuarioPerfil> GetAsync(int id)
        {
            return await _repositorio.GetByIdAsync(id);
        }

        public async Task<int> InsertAsync(UsuarioPerfil usuarioPerfil)
        {
            await _repositorio.AddAsync(usuarioPerfil);
            return usuarioPerfil.Id;
        }

        public async Task UpdateAsync(UsuarioPerfil usuarioPerfil)
        {
            await _repositorio.UpdateAsync(usuarioPerfil);
        }

        public async Task DeleteAsync(UsuarioPerfil usuarioPerfil)
        {
            await _repositorio.DeleteAsync(usuarioPerfil);
        }
    }
}
