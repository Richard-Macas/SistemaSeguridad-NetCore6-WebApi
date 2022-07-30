using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.Rol.Queries.GetAll
{
    public class GetAllRolQuery : IRequest<ResponseData<List<RolResponse>>>
    {
    }

    public class GetAllRolQueryHandler : IRequestHandler<GetAllRolQuery, ResponseData<List<RolResponse>>>
    {
        private readonly IRepositorioRol _repository;
        private readonly IMapper _mapper;

        public GetAllRolQueryHandler(IRepositorioRol repository)
        {
            _repository = repository;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<List<RolResponse>>> Handle(GetAllRolQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var rols = await _repository.GetAllAsync();

                // Mapear dal a dto
                var rolsDto = rols.Select(i => new MapperRol().MapRol(i)).ToList();

                // Response to dto
                var rolsResponse = rolsDto.Select(i => _mapper.Map<RolResponse>(i)).ToList();

                return new ResponseData<List<RolResponse>>(true, "", rolsResponse);
            }
            catch (Exception ex)
            {
                return new ResponseData<List<RolResponse>>(false, $"Error GASQ_01. {ex.Message}", new List<RolResponse>());
            }
        }
    }
}
