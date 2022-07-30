using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Dtos;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;
using System.Security.Claims;

namespace SistemaSeguridad.Domain.Features.Sistema.Queries.GetAllByExpression
{
    public class GetAllSistemaByExpressionQuery : IRequest<ResponseData<List<SistemaResponse>>>
    {
        public ClaimsPrincipal _usuario { get; set; }

        public GetAllSistemaByExpressionQuery(ClaimsPrincipal usuario)
        {
            _usuario = usuario;
        }
    }

    public class GetAllSistemaByExpressionQueryHandler : IRequestHandler<GetAllSistemaByExpressionQuery, ResponseData<List<SistemaResponse>>>
    {
        private readonly IRepositorioSistema _repository;
        private readonly IMapper _mapper;

        public GetAllSistemaByExpressionQueryHandler(IRepositorioSistema repository)
        {
            _repository = repository;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<List<SistemaResponse>>> Handle(GetAllSistemaByExpressionQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var usuarioDataLogin = request._usuario;

                // Obtener los roles del usuario
                var roles = usuarioDataLogin.FindAll(x => x.Type.Contains("role")).Select(x => x.Value).ToList();

                // Buscar los sistema que coincidan con los roles asignado al usuario
                var sistemas = await _repository.GetAll(x => x.PerfilSistemas.Where(p => roles.Any(l => p.IdPerfilNavigation.Nombre == l) && p.EstaHabilitado == true).Count() > 0
                                                            && x.EstaHabilitado == true
                                                            );

                // Mapear dal a dto
                var sistemasDto = sistemas.Select(i => new MapperSistema().MapSistema(i)).ToList();

                // Response to dto
                var sistemasResponse = sistemasDto.Select(i => _mapper.Map<SistemaResponse>(i)).ToList();

                return new ResponseData<List<SistemaResponse>>(true, "", sistemasResponse);
            }
            catch (Exception ex)
            {
                return new ResponseData<List<SistemaResponse>>(false, $"Error GAPSBEQ_01. {ex.Message}", new List<SistemaResponse>());
            }
        }
    }
}
