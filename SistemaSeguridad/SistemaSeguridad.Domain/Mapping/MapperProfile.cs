using AutoMapper;
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
using SistemaSeguridad.Entities.Dtos;

namespace SistemaSeguridad.Domain.Mapping
{
    public class MapperProfile : Profile
    {
        public static MapperConfiguration configuracionMapper = new MapperConfiguration(cfg =>
        {
            // Empresa
            cfg.CreateMap<CreateEmpresaCommand, Empresa>().ReverseMap();
            cfg.CreateMap<UpdateEmpresaCommand, Empresa>().ReverseMap();
            cfg.CreateMap<EmpresaResponse, Empresa>().ReverseMap();

            // EmpresaSistema
            cfg.CreateMap<CreateEmpresaSistemaCommand, EmpresaSistema>().ReverseMap();
            cfg.CreateMap<UpdateEmpresaSistemaCommand, EmpresaSistema>().ReverseMap();
            cfg.CreateMap<EmpresaSistemaResponse, EmpresaSistema>().ReverseMap();

            // Perfil
            cfg.CreateMap<CreatePerfilCommand, Perfil>().ReverseMap();
            cfg.CreateMap<UpdatePerfilCommand, Perfil>().ReverseMap();
            cfg.CreateMap<PerfilResponse, Perfil>().ReverseMap();

            // PerfilSistema
            cfg.CreateMap<CreatePerfilSistemaCommand, PerfilSistema>().ReverseMap();
            cfg.CreateMap<UpdatePerfilSistemaCommand, PerfilSistema>().ReverseMap();
            cfg.CreateMap<PerfilSistemaResponse, PerfilSistema>().ReverseMap();

            // Portal
            cfg.CreateMap<CreatePortalCommand, Portal>().ReverseMap();
            cfg.CreateMap<UpdatePortalCommand, Portal>().ReverseMap();
            cfg.CreateMap<PortalResponse, Portal>().ReverseMap();

            // Recurso
            cfg.CreateMap<CreateRecursoCommand, Recurso>().ReverseMap();
            cfg.CreateMap<UpdateRecursoCommand, Recurso>().ReverseMap();
            cfg.CreateMap<RecursoResponse, Recurso>().ReverseMap();

            // RecursoPerfil
            cfg.CreateMap<CreateRecursoPerfilCommand, RecursoPerfil>().ReverseMap();
            cfg.CreateMap<UpdateRecursoPerfilCommand, RecursoPerfil>().ReverseMap();
            cfg.CreateMap<RecursoPerfilResponse, RecursoPerfil>().ReverseMap();

            // Rol
            cfg.CreateMap<CreateRolCommand, Rol>().ReverseMap();
            cfg.CreateMap<UpdateRolCommand, Rol>().ReverseMap();
            cfg.CreateMap<RolResponse, Rol>().ReverseMap();

            // Sistema
            cfg.CreateMap<CreateSistemaCommand, Sistema>().ReverseMap();
            cfg.CreateMap<UpdateSistemaCommand, Sistema>().ReverseMap();
            cfg.CreateMap<SistemaResponse, Sistema>().ReverseMap();

            // SistemaRecurso
            cfg.CreateMap<CreateSistemaRecursoCommand, SistemaRecurso>().ReverseMap();
            cfg.CreateMap<UpdateSistemaRecursoCommand, SistemaRecurso>().ReverseMap();
            cfg.CreateMap<SistemaRecursoResponse, SistemaRecurso>().ReverseMap();

            // Usuario
            cfg.CreateMap<CreateUsuarioCommand, Usuario>().ReverseMap();
            cfg.CreateMap<UpdateUsuarioCommand, Usuario>().ReverseMap();
            cfg.CreateMap<UsuarioResponse, Usuario>().ReverseMap();

            // UsuarioPerfil
            cfg.CreateMap<CreateUsuarioPerfilCommand, UsuarioPerfil>().ReverseMap();
            cfg.CreateMap<UpdateUsuarioPerfilCommand, UsuarioPerfil>().ReverseMap();
            cfg.CreateMap<UsuarioPerfilResponse, UsuarioPerfil>().ReverseMap();
        });
    }
}
