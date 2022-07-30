using Microsoft.Extensions.DependencyInjection;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Infrastructure.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Infrastructure.RepositoriesCollection
{
    public static class RepositoriesCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            #region Repositories
            services.AddTransient(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));
            services.AddTransient<IRepositorioEmpresa, RepositorioEmpresa>();
            services.AddTransient<IRepositorioEmpresaSistema, RepositorioEmpresaSistema>();
            services.AddTransient<IRepositorioPerfil, RepositorioPerfil>();
            services.AddTransient<IRepositorioPerfilSistema, RepositorioPerfilSistema>();
            services.AddTransient<IRepositorioPortal, RepositorioPortal>();
            services.AddTransient<IRepositorioRecurso, RepositorioRecurso>();
            services.AddTransient<IRepositorioRecursoPerfil, RepositorioRecursoPerfil>();
            services.AddTransient<IRepositorioRol, RepositorioRol>();
            services.AddTransient<IRepositorioSistema, RepositorioSistema>();
            services.AddTransient<IRepositorioSistemaRecurso, RepositorioSistemaRecurso>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRepositorioUsuario, RepositorioUsuario>();
            services.AddTransient<IRepositorioUsuarioPerfil, RepositorioUsuarioPerfil>();

            #endregion Repositories
        }
    }
}
