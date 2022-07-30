using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.Portal.Commands.Create
{
    public class CreatePortalCommand : PortalResponse, IRequest<ResponseData<PortalResponse>>
    {

    }

    public class CreatePortalCommandHandler : IRequestHandler<CreatePortalCommand, ResponseData<PortalResponse>>
    {
        private readonly IRepositorioPortal _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePortalCommandHandler(IRepositorioPortal repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<PortalResponse>> Handle(CreatePortalCommand request, CancellationToken cancellationToken)
        {
            try
            {

                // Mapear de dto a dal
                var portal = new MapperPortal().MapPortal(_mapper.Map<Entities.Dtos.Portal>(request));

                // Insertar
                await _repository.InsertAsync(portal);
                // Guardar cambios
                await _unitOfWork.Commit(cancellationToken);

                // Mapear dal to dto
                var portalResponse = _mapper.Map<PortalResponse>(new MapperPortal().MapPortal(portal));

                return new ResponseData<PortalResponse>(true, "", portalResponse);

            }
            catch (Exception ex)
            {
                return new ResponseData<PortalResponse>(false, $"Error CSC_01. ${ex.Message}", null);
            }
        }
    }
}
