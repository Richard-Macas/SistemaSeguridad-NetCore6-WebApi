using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.Sistema.Commands.Update
{
    public class UpdateSistemaCommand : SistemaResponse, IRequest<ResponseData<SistemaResponse>>
    {

    }

    public class UpdateSistemaCommandHandler : IRequestHandler<UpdateSistemaCommand, ResponseData<SistemaResponse>>
    {
        private readonly IRepositorioSistema _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSistemaCommandHandler(IRepositorioSistema repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<SistemaResponse>> Handle(UpdateSistemaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Verificar que exista el Id
                var sistemaValid = await _repository.GetAsync(request.Id);

                if (sistemaValid == null)
                    return new ResponseData<SistemaResponse>(true, $"El sistema con Id: {request.Id}, no existe", null);

                // Mapear de dto a dal
                var sistema = new MapperSistema().MapSistema(_mapper.Map<Entities.Dtos.Sistema>(request));

                // Actualizar
                await _repository.UpdateAsync(sistema);
                // Guardar cambios
                await _unitOfWork.Commit(cancellationToken);

                // Mapear dal to dto to response
                var sistemaResponse = _mapper.Map<SistemaResponse>(new MapperSistema().MapSistema(sistema));

                return new ResponseData<SistemaResponse>(true, "", sistemaResponse);

            }
            catch (Exception ex)
            {
                return new ResponseData<SistemaResponse>(false, $"Error USC_01. ${ex.Message}", null);
            }
        }
    }
}
