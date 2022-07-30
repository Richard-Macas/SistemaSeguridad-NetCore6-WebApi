using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.Perfil.Queries.GetAll
{
    public class GetAllPerfilQuery : IRequest<ResponseData<List<PerfilResponse>>>
    {
    }

    public class GetAllPerfilQueryHandler : IRequestHandler<GetAllPerfilQuery, ResponseData<List<PerfilResponse>>>
    {
        private readonly IRepositorioPerfil _repository;
        private readonly IMapper _mapper;

        public GetAllPerfilQueryHandler(IRepositorioPerfil repository)
        {
            _repository = repository;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<List<PerfilResponse>>> Handle(GetAllPerfilQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var perfils = await _repository.GetAllAsync();

                // Mapear dal a dto
                var perfilsDto = perfils.Select(i => new MapperPerfil().MapPerfil(i)).ToList();

                // Response to dto
                var perfilsResponse = perfilsDto.Select(i => _mapper.Map<PerfilResponse>(i)).ToList();

                return new ResponseData<List<PerfilResponse>>(true, "", perfilsResponse);
            }
            catch (Exception ex)
            {
                return new ResponseData<List<PerfilResponse>>(false, $"Error GASQ_01. {ex.Message}", new List<PerfilResponse>());
            }
        }
    }
}
