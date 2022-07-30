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
    public class RepositorioEmpresaSistema : IRepositorioEmpresaSistema
    {
        private readonly IRepositorioGenerico<EmpresaSistema> _repositorio;

        public RepositorioEmpresaSistema(IRepositorioGenerico<EmpresaSistema> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<EmpresaSistema>> GetAllAsync()
        {
            return await _repositorio.GetAllAsync();
        }

        public async Task<EmpresaSistema> GetAsync(int id)
        {
            return await _repositorio.GetByIdAsync(id);
        }

        public async Task<int> InsertAsync(EmpresaSistema empresaSistema)
        {
            await _repositorio.AddAsync(empresaSistema);
            return empresaSistema.Id;
        }

        public async Task UpdateAsync(EmpresaSistema empresaSistema)
        {
            await _repositorio.UpdateAsync(empresaSistema);
        }

        public async Task DeleteAsync(EmpresaSistema empresaSistema)
        {
            await _repositorio.DeleteAsync(empresaSistema);
        }
    }
}
