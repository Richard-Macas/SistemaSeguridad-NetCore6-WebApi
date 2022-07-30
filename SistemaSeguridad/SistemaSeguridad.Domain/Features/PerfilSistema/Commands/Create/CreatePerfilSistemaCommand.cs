using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.PerfilSistema.Commands.Create
{
    public class CreatePerfilSistemaCommand : PerfilSistemaResponse, IRequest<ResponseData<PerfilSistemaResponse>>
    {

    }

    public class CreatePerfilSistemaCommandHandler : IRequestHandler<CreatePerfilSistemaCommand, ResponseData<PerfilSistemaResponse>>
    {
        private readonly IRepositorioPerfilSistema _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePerfilSistemaCommandHandler(IRepositorioPerfilSistema repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<PerfilSistemaResponse>> Handle(CreatePerfilSistemaCommand request, CancellationToken cancellationToken)
        {
            try
            {

                // Mapear de dto a dal
                var perfilSistema = new MapperPerfilSistema().MapPerfilSistema(_mapper.Map<Entities.Dtos.PerfilSistema>(request));

                // Insertar
                await _repository.InsertAsync(perfilSistema);
                // Guardar cambios
                await _unitOfWork.Commit(cancellationToken);

                // Mapear dal to dto
                var perfilSistemaResponse = _mapper.Map<PerfilSistemaResponse>(new MapperPerfilSistema().MapPerfilSistema(perfilSistema));

                return new ResponseData<PerfilSistemaResponse>(true, "", perfilSistemaResponse);

            }
            catch (Exception ex)
            {
                return new ResponseData<PerfilSistemaResponse>(false, $"Error CSC_01. ${ex.Message}", null);
            }
        }
    }
}
