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
    public class RepositorioEmpresa : IRepositorioEmpresa
    {
        private readonly IRepositorioGenerico<Empresa> _repositorio;

        public RepositorioEmpresa(IRepositorioGenerico<Empresa> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<Empresa>> GetAllAsync()
        {
            return await _repositorio.GetAllAsync();
        }

        public async Task<Empresa> GetAsync(int id)
        {
            return await _repositorio.GetByIdAsync(id);
        }

        public async Task<int> InsertAsync(Empresa empresa)
        {
            await _repositorio.AddAsync(empresa);
            return empresa.Id;
        }

        public async Task UpdateAsync(Empresa empresa)
        {
            await _repositorio.UpdateAsync(empresa);
        }

        public async Task DeleteAsync(Empresa empresa)
        {
            await _repositorio.DeleteAsync(empresa);
        }
    }
}
