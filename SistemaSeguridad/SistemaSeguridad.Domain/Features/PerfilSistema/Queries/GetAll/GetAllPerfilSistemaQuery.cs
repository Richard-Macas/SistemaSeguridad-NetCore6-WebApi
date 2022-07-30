using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.PerfilSistema.Queries.GetAll
{
    public class GetAllPerfilSistemaQuery : IRequest<ResponseData<List<PerfilSistemaResponse>>>
    {
    }

    public class GetAllPerfilSistemaQueryHandler : IRequestHandler<GetAllPerfilSistemaQuery, ResponseData<List<PerfilSistemaResponse>>>
    {
        private readonly IRepositorioPerfilSistema _repository;
        private readonly IMapper _mapper;

        public GetAllPerfilSistemaQueryHandler(IRepositorioPerfilSistema repository)
        {
            _repository = repository;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<List<PerfilSistemaResponse>>> Handle(GetAllPerfilSistemaQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var perfilSistemas = await _repository.GetAllAsync();

                // Mapear dal a dto
                var perfilSistemasDto = perfilSistemas.Select(i => new MapperPerfilSistema().MapPerfilSistema(i)).ToList();

                // Response to dto
                var perfilSistemasResponse = perfilSistemasDto.Select(i => _mapper.Map<PerfilSistemaResponse>(i)).ToList();

                return new ResponseData<List<PerfilSistemaResponse>>(true, "", perfilSistemasResponse);
            }
            catch (Exception ex)
            {
                return new ResponseData<List<PerfilSistemaResponse>>(false, $"Error GASQ_01. {ex.Message}", new List<PerfilSistemaResponse>());
            }
        }
    }
}
