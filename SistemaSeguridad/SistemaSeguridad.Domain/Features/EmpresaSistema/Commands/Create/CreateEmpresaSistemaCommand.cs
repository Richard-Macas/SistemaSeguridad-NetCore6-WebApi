using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.EmpresaSistema.Commands.Create
{
    public class CreateEmpresaSistemaCommand : EmpresaSistemaResponse, IRequest<ResponseData<EmpresaSistemaResponse>>
    {

    }

    public class CreateEmpresaSistemaCommandHandler : IRequestHandler<CreateEmpresaSistemaCommand, ResponseData<EmpresaSistemaResponse>>
    {
        private readonly IRepositorioEmpresaSistema _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateEmpresaSistemaCommandHandler(IRepositorioEmpresaSistema repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<EmpresaSistemaResponse>> Handle(CreateEmpresaSistemaCommand request, CancellationToken cancellationToken)
        {
            try
            {

                // Mapear de dto a dal
                var empresaSistema = new MapperEmpresaSistema().MapEmpresaSistema(_mapper.Map<Entities.Dtos.EmpresaSistema>(request));

                // Insertar
                await _repository.InsertAsync(empresaSistema);
                // Guardar cambios
                await _unitOfWork.Commit(cancellationToken);

                // Mapear dal to dto
                var empresaSistemaResponse = _mapper.Map<EmpresaSistemaResponse>(new MapperEmpresaSistema().MapEmpresaSistema(empresaSistema));

                return new ResponseData<EmpresaSistemaResponse>(true, "", empresaSistemaResponse);

            }
            catch (Exception ex)
            {
                return new ResponseData<EmpresaSistemaResponse>(false, $"Error CSC_01. ${ex.Message}", null);
            }
        }
    }
}
