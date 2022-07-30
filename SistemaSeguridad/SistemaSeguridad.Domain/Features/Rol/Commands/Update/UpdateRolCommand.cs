using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.Rol.Commands.Update
{
    public class UpdateRolCommand : RolResponse, IRequest<ResponseData<RolResponse>>
    {

    }

    public class UpdateRolCommandHandler : IRequestHandler<UpdateRolCommand, ResponseData<RolResponse>>
    {
        private readonly IRepositorioRol _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRolCommandHandler(IRepositorioRol repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<RolResponse>> Handle(UpdateRolCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Verificar que exista el Id
                var rolValid = await _repository.GetAsync(request.Id);

                if (rolValid == null)
                    return new ResponseData<RolResponse>(true, $"El rol con Id: {request.Id}, no existe", null);

                // Mapear de dto a dal
                var rol = new MapperRol().MapRol(_mapper.Map<Entities.Dtos.Rol>(request));

                // Actualizar
                await _repository.UpdateAsync(rol);
                // Guardar cambios
                await _unitOfWork.Commit(cancellationToken);

                // Mapear dal to dto to response
                var rolResponse = _mapper.Map<RolResponse>(new MapperRol().MapRol(rol));

                return new ResponseData<RolResponse>(true, "", rolResponse);

            }
            catch (Exception ex)
            {
                return new ResponseData<RolResponse>(false, $"Error USC_01. ${ex.Message}", null);
            }
        }
    }
}
