using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.Portal.Queries.GetAll
{
    public class GetAllPortalQuery : IRequest<ResponseData<List<PortalResponse>>>
    {
    }

    public class GetAllPortalQueryHandler : IRequestHandler<GetAllPortalQuery, ResponseData<List<PortalResponse>>>
    {
        private readonly IRepositorioPortal _repository;
        private readonly IMapper _mapper;

        public GetAllPortalQueryHandler(IRepositorioPortal repository)
        {
            _repository = repository;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<List<PortalResponse>>> Handle(GetAllPortalQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var portals = await _repository.GetAllAsync();

                // Mapear dal a dto
                var portalsDto = portals.Select(i => new MapperPortal().MapPortal(i)).ToList();

                // Response to dto
                var portalsResponse = portalsDto.Select(i => _mapper.Map<PortalResponse>(i)).ToList();

                return new ResponseData<List<PortalResponse>>(true, "", portalsResponse);
            }
            catch (Exception ex)
            {
                return new ResponseData<List<PortalResponse>>(false, $"Error GASQ_01. {ex.Message}", new List<PortalResponse>());
            }
        }
    }
}
