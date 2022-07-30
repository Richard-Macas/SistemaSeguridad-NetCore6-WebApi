using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.Empresa.Commands.Update
{
    public class UpdateEmpresaCommand : EmpresaResponse, IRequest<ResponseData<EmpresaResponse>>
    {

    }

    public class UpdateEmpresaCommandHandler : IRequestHandler<UpdateEmpresaCommand, ResponseData<EmpresaResponse>>
    {
        private readonly IRepositorioEmpresa _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateEmpresaCommandHandler(IRepositorioEmpresa repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<EmpresaResponse>> Handle(UpdateEmpresaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Verificar que exista el Id
                var empresaValid = await _repository.GetAsync(request.Id);

                if (empresaValid == null)
                    return new ResponseData<EmpresaResponse>(true, $"El empresa con Id: {request.Id}, no existe", null);

                // Mapear de dto a dal
                var empresa = new MapperEmpresa().MapEmpresa(_mapper.Map<Entities.Dtos.Empresa>(request));

                // Actualizar
                await _repository.UpdateAsync(empresa);
                // Guardar cambios
                await _unitOfWork.Commit(cancellationToken);

                // Mapear dal to dto to response
                var empresaResponse = _mapper.Map<EmpresaResponse>(new MapperEmpresa().MapEmpresa(empresa));

                return new ResponseData<EmpresaResponse>(true, "", empresaResponse);

            }
            catch (Exception ex)
            {
                return new ResponseData<EmpresaResponse>(false, $"Error USC_01. ${ex.Message}", null);
            }
        }
    }
}
