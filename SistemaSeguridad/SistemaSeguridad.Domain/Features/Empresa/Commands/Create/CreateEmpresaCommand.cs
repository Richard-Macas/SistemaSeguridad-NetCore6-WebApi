using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.Empresa.Commands.Create
{
    public class CreateEmpresaCommand : EmpresaResponse, IRequest<ResponseData<EmpresaResponse>>
    {

    }

    public class CreateEmpresaCommandHandler : IRequestHandler<CreateEmpresaCommand, ResponseData<EmpresaResponse>>
    {
        private readonly IRepositorioEmpresa _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateEmpresaCommandHandler(IRepositorioEmpresa repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<EmpresaResponse>> Handle(CreateEmpresaCommand request, CancellationToken cancellationToken)
        {
            try
            {

                // Mapear de dto a dal
                var empresa = new MapperEmpresa().MapEmpresa(_mapper.Map<Entities.Dtos.Empresa>(request));

                // Insertar
                await _repository.InsertAsync(empresa);
                // Guardar cambios
                await _unitOfWork.Commit(cancellationToken);

                // Mapear dal to dto
                var empresaResponse = _mapper.Map<EmpresaResponse>(new MapperEmpresa().MapEmpresa(empresa));

                return new ResponseData<EmpresaResponse>(true, "", empresaResponse);

            }
            catch (Exception ex)
            {
                return new ResponseData<EmpresaResponse>(false, $"Error CSC_01. ${ex.Message}", null);
            }
        }
    }
}
