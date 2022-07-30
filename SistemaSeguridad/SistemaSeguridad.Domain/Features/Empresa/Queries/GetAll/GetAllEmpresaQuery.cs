using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.Empresa.Queries.GetAll
{
    public class GetAllEmpresaQuery : IRequest<ResponseData<List<EmpresaResponse>>>
    {
    }

    public class GetAllEmpresaQueryHandler : IRequestHandler<GetAllEmpresaQuery, ResponseData<List<EmpresaResponse>>>
    {
        private readonly IRepositorioEmpresa _repository;
        private readonly IMapper _mapper;

        public GetAllEmpresaQueryHandler(IRepositorioEmpresa repository)
        {
            _repository = repository;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<List<EmpresaResponse>>> Handle(GetAllEmpresaQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var empresas = await _repository.GetAllAsync();

                // Mapear dal a dto
                var empresasDto = empresas.Select(i => new MapperEmpresa().MapEmpresa(i)).ToList();

                // Response to dto
                var empresasResponse = empresasDto.Select(i => _mapper.Map<EmpresaResponse>(i)).ToList();

                return new ResponseData<List<EmpresaResponse>>(true, "", empresasResponse);
            }
            catch (Exception ex)
            {
                return new ResponseData<List<EmpresaResponse>>(false, $"Error GASQ_01. {ex.Message}", new List<EmpresaResponse>());
            }
        }
    }
}
