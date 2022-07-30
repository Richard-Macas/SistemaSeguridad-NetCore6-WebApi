using AutoMapper;
using SistemaSeguridad.Domain.Features.Login;
using SistemaSeguridad.Domain.Features.Login.Queries.GetByExpression;
using SistemaSeguridad.Domain.Features.Empresa;
using SistemaSeguridad.Domain.Features.Empresa.Commands.Create;
using SistemaSeguridad.Domain.Features.Empresa.Commands.Update;
using SistemaSeguridad.Domain.Features.EmpresaSistema;
using SistemaSeguridad.Domain.Features.EmpresaSistema.Commands.Create;
using SistemaSeguridad.Domain.Features.EmpresaSistema.Commands.Update;
using SistemaSeguridad.Domain.Features.Perfil;
using SistemaSeguridad.Domain.Features.Perfil.Commands.Create;
using SistemaSeguridad.Domain.Features.Perfil.Commands.Update;
using SistemaSeguridad.Domain.Features.PerfilSistema;
using SistemaSeguridad.Domain.Features.PerfilSistema.Commands.Create;
using SistemaSeguridad.Domain.Features.PerfilSistema.Commands.Update;
using SistemaSeguridad.Domain.Features.Portal;
using SistemaSeguridad.Domain.Features.Portal.Commands.Create;
using SistemaSeguridad.Domain.Features.Portal.Commands.Update;
using SistemaSeguridad.Domain.Features.Recursos;
using SistemaSeguridad.Domain.Features.Recursos.Commands.Create;
using SistemaSeguridad.Domain.Features.Recursos.Commands.Update;
using SistemaSeguridad.Domain.Features.RecursoPerfil;
using SistemaSeguridad.Domain.Features.RecursoPerfil.Commands.Create;
using SistemaSeguridad.Domain.Features.RecursoPerfil.Commands.Update;
using SistemaSeguridad.Domain.Features.Rol;
using SistemaSeguridad.Domain.Features.Rol.Commands.Create;
using SistemaSeguridad.Domain.Features.Rol.Commands.Update;
using SistemaSeguridad.Domain.Features.Sistema;
using SistemaSeguridad.Domain.Features.Sistema.Commands.Create;
using SistemaSeguridad.Domain.Features.Sistema.Commands.Update;
using SistemaSeguridad.Domain.Features.SistemaRecurso;
using SistemaSeguridad.Domain.Features.SistemaRecurso.Commands.Create;
using SistemaSeguridad.Domain.Features.SistemaRecurso.Commands.Update;
using SistemaSeguridad.Domain.Features.Usuario;
using SistemaSeguridad.Domain.Features.Usuario.Commands.Create;
using SistemaSeguridad.Domain.Features.Usuario.Commands.Update;
using SistemaSeguridad.Domain.Features.UsuarioPerfil;
using SistemaSeguridad.Domain.Features.UsuarioPerfil.Commands.Create;
using SistemaSeguridad.Domain.Features.UsuarioPerfil.Commands.Update;

namespace SistemaSeguridad.API.Mapping
{
    public class MapperProfile : Profile
    {
        public static MapperConfiguration configuracionMapper = new MapperConfiguration(cfg =>
        {
            // Login
            cfg.CreateMap<GetLoginTokenByExpressionQuery, LoginResponse>().ReverseMap();

            // Empresa
            cfg.CreateMap<CreateEmpresaCommand, EmpresaResponse>().ReverseMap();
            cfg.CreateMap<UpdateEmpresaCommand, EmpresaResponse>().ReverseMap();

            // EmpresaPerfil
            cfg.CreateMap<CreateEmpresaSistemaCommand, EmpresaSistemaResponse>().ReverseMap();
            cfg.CreateMap<UpdateEmpresaSistemaCommand, EmpresaSistemaResponse>().ReverseMap();

            // Perfil
            cfg.CreateMap<CreatePerfilCommand, PerfilResponse>().ReverseMap();
            cfg.CreateMap<UpdatePerfilCommand, PerfilResponse>().ReverseMap();

            // PerfilSistema
            cfg.CreateMap<CreatePerfilSistemaCommand, PerfilSistemaResponse>().ReverseMap();
            cfg.CreateMap<UpdatePerfilSistemaCommand, PerfilSistemaResponse>().ReverseMap();

            // Portal
            cfg.CreateMap<CreatePortalCommand, PortalResponse>().ReverseMap();
            cfg.CreateMap<UpdatePortalCommand, PortalResponse>().ReverseMap();

            // Recurso
            cfg.CreateMap<CreateRecursoCommand, RecursoResponse>().ReverseMap();
            cfg.CreateMap<UpdateRecursoCommand, RecursoResponse>().ReverseMap();

            // RecursoPerfil
            cfg.CreateMap<CreateRecursoPerfilCommand, RecursoPerfilResponse>().ReverseMap();
            cfg.CreateMap<UpdateRecursoPerfilCommand, RecursoPerfilResponse>().ReverseMap();

            // Rol
            cfg.CreateMap<CreateRolCommand, RolResponse>().ReverseMap();
            cfg.CreateMap<UpdateRolCommand, RolResponse>().ReverseMap();

            // Sistema
            cfg.CreateMap<CreateSistemaCommand, SistemaResponse>().ReverseMap();
            cfg.CreateMap<UpdateSistemaCommand, SistemaResponse>().ReverseMap();

            // SistemaRecurso
            cfg.CreateMap<CreateSistemaRecursoCommand, SistemaRecursoResponse>().ReverseMap();
            cfg.CreateMap<UpdateSistemaRecursoCommand, SistemaRecursoResponse>().ReverseMap();

            // Usuario
            cfg.CreateMap<CreateUsuarioCommand, UsuarioResponse>().ReverseMap();
            cfg.CreateMap<UpdateUsuarioCommand, UsuarioResponse>().ReverseMap();

            // UsuarioPerfil
            cfg.CreateMap<CreateUsuarioPerfilCommand, UsuarioPerfilResponse>().ReverseMap();
            cfg.CreateMap<UpdateUsuarioPerfilCommand, UsuarioPerfilResponse>().ReverseMap();

        });
    }
}
