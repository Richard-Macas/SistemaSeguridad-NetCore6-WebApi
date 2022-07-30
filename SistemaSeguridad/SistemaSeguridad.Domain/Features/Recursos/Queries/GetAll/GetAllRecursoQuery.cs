using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.Recursos.Queries.GetAllByExpression
{
    public class GetAllRecursoQuery : IRequest<ResponseData<List<RecursoResponse>>>
    {
    }

    public class GetAllRecursoQueryHandler : IRequestHandler<GetAllRecursoQuery, ResponseData<List<RecursoResponse>>>
    {
        private readonly IRepositorioRecurso _repository;
        private readonly IMapper _mapper;

        public GetAllRecursoQueryHandler(IRepositorioRecurso repository)
        {
            _repository = repository;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<List<RecursoResponse>>> Handle(GetAllRecursoQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var recursos = await _repository.GetAllAsync();

                // Mapear dal a dto
                var recursosDto = recursos.Select(i => new MapperRecurso().MapRecurso(i)).ToList();

                // Response to dto
                var recursosResponse = recursosDto.Select(i => _mapper.Map<RecursoResponse>(i)).ToList();

                return new ResponseData<List<RecursoResponse>>(true, "", recursosResponse);
            }
            catch (Exception ex)
            {
                return new ResponseData<List<RecursoResponse>>(false, $"Error GASQ_01. {ex.Message}", new List<RecursoResponse>());
            }
        }
    }
}
