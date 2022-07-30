using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.Portal.Commands.Update
{
    public class UpdatePortalCommand : PortalResponse, IRequest<ResponseData<PortalResponse>>
    {

    }

    public class UpdatePortalCommandHandler : IRequestHandler<UpdatePortalCommand, ResponseData<PortalResponse>>
    {
        private readonly IRepositorioPortal _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePortalCommandHandler(IRepositorioPortal repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<PortalResponse>> Handle(UpdatePortalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Verificar que exista el Id
                var portalValid = await _repository.GetAsync(request.Id);

                if (portalValid == null)
                    return new ResponseData<PortalResponse>(true, $"El portal con Id: {request.Id}, no existe", null);

                // Mapear de dto a dal
                var portal = new MapperPortal().MapPortal(_mapper.Map<Entities.Dtos.Portal>(request));

                // Actualizar
                await _repository.UpdateAsync(portal);
                // Guardar cambios
                await _unitOfWork.Commit(cancellationToken);

                // Mapear dal to dto to response
                var portalResponse = _mapper.Map<PortalResponse>(new MapperPortal().MapPortal(portal));

                return new ResponseData<PortalResponse>(true, "", portalResponse);

            }
            catch (Exception ex)
            {
                return new ResponseData<PortalResponse>(false, $"Error USC_01. ${ex.Message}", null);
            }
        }
    }
}
