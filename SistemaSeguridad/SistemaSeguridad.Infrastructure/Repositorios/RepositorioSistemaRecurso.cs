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
    public class RepositorioSistemaRecurso : IRepositorioSistemaRecurso
    {
        private readonly IRepositorioGenerico<SistemaRecurso> _repositorio;

        public RepositorioSistemaRecurso(IRepositorioGenerico<SistemaRecurso> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<SistemaRecurso>> GetAllAsync()
        {
            return await _repositorio.GetAllAsync();
        }

        public async Task<SistemaRecurso> GetAsync(int id)
        {
            return await _repositorio.GetByIdAsync(id);
        }

        public async Task<int> InsertAsync(SistemaRecurso sistemaRecurso)
        {
            await _repositorio.AddAsync(sistemaRecurso);
            return sistemaRecurso.Id;
        }

        public async Task UpdateAsync(SistemaRecurso sistemaRecurso)
        {
            await _repositorio.UpdateAsync(sistemaRecurso);
        }

        public async Task DeleteAsync(SistemaRecurso sistemaRecurso)
        {
            await _repositorio.DeleteAsync(sistemaRecurso);
        }
    }
}
