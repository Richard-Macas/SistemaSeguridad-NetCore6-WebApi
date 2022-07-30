using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.RecursoPerfil.Queries.GetAll
{
    public class GetAllRecursoPerfilQuery : IRequest<ResponseData<List<RecursoPerfilResponse>>>
    {
    }

    public class GetAllRecursoPerfilQueryHandler : IRequestHandler<GetAllRecursoPerfilQuery, ResponseData<List<RecursoPerfilResponse>>>
    {
        private readonly IRepositorioRecursoPerfil _repository;
        private readonly IMapper _mapper;

        public GetAllRecursoPerfilQueryHandler(IRepositorioRecursoPerfil repository)
        {
            _repository = repository;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<List<RecursoPerfilResponse>>> Handle(GetAllRecursoPerfilQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var recursoPerfils = await _repository.GetAllAsync();

                // Mapear dal a dto
                var recursoPerfilsDto = recursoPerfils.Select(i => new MapperRecursoPerfil().MapRecursoPerfil(i)).ToList();

                // Response to dto
                var recursoPerfilsResponse = recursoPerfilsDto.Select(i => _mapper.Map<RecursoPerfilResponse>(i)).ToList();

                return new ResponseData<List<RecursoPerfilResponse>>(true, "", recursoPerfilsResponse);
            }
            catch (Exception ex)
            {
                return new ResponseData<List<RecursoPerfilResponse>>(false, $"Error GASQ_01. {ex.Message}", new List<RecursoPerfilResponse>());
            }
        }
    }
}
