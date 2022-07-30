using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.SistemaRecurso.Queries.GetAll
{
    public class GetAllSistemaRecursoQuery : IRequest<ResponseData<List<SistemaRecursoResponse>>>
    {
    }

    public class GetAllSistemaRecursoQueryHandler : IRequestHandler<GetAllSistemaRecursoQuery, ResponseData<List<SistemaRecursoResponse>>>
    {
        private readonly IRepositorioSistemaRecurso _repository;
        private readonly IMapper _mapper;

        public GetAllSistemaRecursoQueryHandler(IRepositorioSistemaRecurso repository)
        {
            _repository = repository;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<List<SistemaRecursoResponse>>> Handle(GetAllSistemaRecursoQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var sistemaRecursos = await _repository.GetAllAsync();

                // Mapear dal a dto
                var sistemaRecursosDto = sistemaRecursos.Select(i => new MapperSistemaRecurso().MapSistemaRecurso(i)).ToList();

                // Response to dto
                var sistemaRecursosResponse = sistemaRecursosDto.Select(i => _mapper.Map<SistemaRecursoResponse>(i)).ToList();

                return new ResponseData<List<SistemaRecursoResponse>>(true, "", sistemaRecursosResponse);
            }
            catch (Exception ex)
            {
                return new ResponseData<List<SistemaRecursoResponse>>(false, $"Error GASQ_01. {ex.Message}", new List<SistemaRecursoResponse>());
            }
        }
    }
}
