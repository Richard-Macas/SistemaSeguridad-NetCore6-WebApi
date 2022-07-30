using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.EmpresaSistema.Queries.GetAll
{
    public class GetAllEmpresaSistemaQuery : IRequest<ResponseData<List<EmpresaSistemaResponse>>>
    {
    }

    public class GetAllEmpresaSistemaQueryHandler : IRequestHandler<GetAllEmpresaSistemaQuery, ResponseData<List<EmpresaSistemaResponse>>>
    {
        private readonly IRepositorioEmpresaSistema _repository;
        private readonly IMapper _mapper;

        public GetAllEmpresaSistemaQueryHandler(IRepositorioEmpresaSistema repository)
        {
            _repository = repository;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<List<EmpresaSistemaResponse>>> Handle(GetAllEmpresaSistemaQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var empresaSistemas = await _repository.GetAllAsync();

                // Mapear dal a dto
                var empresaSistemasDto = empresaSistemas.Select(i => new MapperEmpresaSistema().MapEmpresaSistema(i)).ToList();

                // Response to dto
                var empresaSistemasResponse = empresaSistemasDto.Select(i => _mapper.Map<EmpresaSistemaResponse>(i)).ToList();

                return new ResponseData<List<EmpresaSistemaResponse>>(true, "", empresaSistemasResponse);
            }
            catch (Exception ex)
            {
                return new ResponseData<List<EmpresaSistemaResponse>>(false, $"Error GASQ_01. {ex.Message}", new List<EmpresaSistemaResponse>());
            }
        }
    }
}
