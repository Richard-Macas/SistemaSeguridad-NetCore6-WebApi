using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.Rol.Commands.Create
{
    public class CreateRolCommand : RolResponse, IRequest<ResponseData<RolResponse>>
    {

    }

    public class CreateRolCommandHandler : IRequestHandler<CreateRolCommand, ResponseData<RolResponse>>
    {
        private readonly IRepositorioRol _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateRolCommandHandler(IRepositorioRol repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<RolResponse>> Handle(CreateRolCommand request, CancellationToken cancellationToken)
        {
            try
            {

                // Mapear de dto a dal
                var rol = new MapperRol().MapRol(_mapper.Map<Entities.Dtos.Rol>(request));

                // Insertar
                await _repository.InsertAsync(rol);
                // Guardar cambios
                await _unitOfWork.Commit(cancellationToken);

                // Mapear dal to dto
                var rolResponse = _mapper.Map<RolResponse>(new MapperRol().MapRol(rol));

                return new ResponseData<RolResponse>(true, "", rolResponse);

            }
            catch (Exception ex)
            {
                return new ResponseData<RolResponse>(false, $"Error CSC_01. ${ex.Message}", null);
            }
        }
    }
}
