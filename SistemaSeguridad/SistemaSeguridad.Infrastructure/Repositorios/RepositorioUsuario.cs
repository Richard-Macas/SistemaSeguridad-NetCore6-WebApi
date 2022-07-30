using Microsoft.EntityFrameworkCore;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Entities.Entities;
using SistemaSeguridad.Repository.Persistencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace SistemaSeguridad.Infrastructure.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private readonly IRepositorioGenerico<Usuario> _repositorio;

        public RepositorioUsuario(IRepositorioGenerico<Usuario> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Usuario> Get(Expression<Func<Usuario, bool>> expr)
        {
            return await _repositorio.Entities
                        .Include(x => x.UsuarioPerfils).ThenInclude(x => x.IdPerfilNavigation)
                        .FirstOrDefaultAsync(expr);
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _repositorio.GetAllAsync();
        }

        public async Task<Usuario> GetAsync(int id)
        {
            return await _repositorio.GetByIdAsync(id);
        }

        public async Task<int> InsertAsync(Usuario usuario)
        {
            await _repositorio.AddAsync(usuario);
            return usuario.Id;
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            await _repositorio.UpdateAsync(usuario);
        }

        public async Task DeleteAsync(Usuario usuario)
        {
            await _repositorio.DeleteAsync(usuario);
        }

    }
}
