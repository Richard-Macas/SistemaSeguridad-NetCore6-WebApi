using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.PerfilSistema.Commands.Update
{
    public class UpdatePerfilSistemaCommand : PerfilSistemaResponse, IRequest<ResponseData<PerfilSistemaResponse>>
    {

    }

    public class UpdatePerfilSistemaCommandHandler : IRequestHandler<UpdatePerfilSistemaCommand, ResponseData<PerfilSistemaResponse>>
    {
        private readonly IRepositorioPerfilSistema _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePerfilSistemaCommandHandler(IRepositorioPerfilSistema repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<PerfilSistemaResponse>> Handle(UpdatePerfilSistemaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Verificar que exista el Id
                var perfilSistemaValid = await _repository.GetAsync(request.Id);

                if (perfilSistemaValid == null)
                    return new ResponseData<PerfilSistemaResponse>(true, $"El perfilSistema con Id: {request.Id}, no existe", null);

                // Mapear de dto a dal
                var perfilSistema = new MapperPerfilSistema().MapPerfilSistema(_mapper.Map<Entities.Dtos.PerfilSistema>(request));

                // Actualizar
                await _repository.UpdateAsync(perfilSistema);
                // Guardar cambios
                await _unitOfWork.Commit(cancellationToken);

                // Mapear dal to dto to response
                var perfilSistemaResponse = _mapper.Map<PerfilSistemaResponse>(new MapperPerfilSistema().MapPerfilSistema(perfilSistema));

                return new ResponseData<PerfilSistemaResponse>(true, "", perfilSistemaResponse);

            }
            catch (Exception ex)
            {
                return new ResponseData<PerfilSistemaResponse>(false, $"Error USC_01. ${ex.Message}", null);
            }
        }
    }
}
