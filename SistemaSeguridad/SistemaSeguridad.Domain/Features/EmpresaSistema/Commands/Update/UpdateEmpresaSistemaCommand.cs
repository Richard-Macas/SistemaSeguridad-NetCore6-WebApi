using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.EmpresaSistema.Commands.Update
{
    public class UpdateEmpresaSistemaCommand : EmpresaSistemaResponse, IRequest<ResponseData<EmpresaSistemaResponse>>
    {

    }

    public class UpdateEmpresaSistemaCommandHandler : IRequestHandler<UpdateEmpresaSistemaCommand, ResponseData<EmpresaSistemaResponse>>
    {
        private readonly IRepositorioEmpresaSistema _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateEmpresaSistemaCommandHandler(IRepositorioEmpresaSistema repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<EmpresaSistemaResponse>> Handle(UpdateEmpresaSistemaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Verificar que exista el Id
                var empresaSistemaValid = await _repository.GetAsync(request.Id);

                if (empresaSistemaValid == null)
                    return new ResponseData<EmpresaSistemaResponse>(true, $"El empresaSistema con Id: {request.Id}, no existe", null);

                // Mapear de dto a dal
                var empresaSistema = new MapperEmpresaSistema().MapEmpresaSistema(_mapper.Map<Entities.Dtos.EmpresaSistema>(request));

                // Actualizar
                await _repository.UpdateAsync(empresaSistema);
                // Guardar cambios
                await _unitOfWork.Commit(cancellationToken);

                // Mapear dal to dto to response
                var empresaSistemaResponse = _mapper.Map<EmpresaSistemaResponse>(new MapperEmpresaSistema().MapEmpresaSistema(empresaSistema));

                return new ResponseData<EmpresaSistemaResponse>(true, "", empresaSistemaResponse);

            }
            catch (Exception ex)
            {
                return new ResponseData<EmpresaSistemaResponse>(false, $"Error USC_01. ${ex.Message}", null);
            }
        }
    }
}
