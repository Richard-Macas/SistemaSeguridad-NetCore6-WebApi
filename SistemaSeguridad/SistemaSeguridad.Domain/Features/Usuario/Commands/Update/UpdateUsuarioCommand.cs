using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.Usuario.Commands.Update
{
    public class UpdateUsuarioCommand : UsuarioResponse, IRequest<ResponseData<UsuarioResponse>>
    {

    }

    public class UpdateUsuarioCommandHandler : IRequestHandler<UpdateUsuarioCommand, ResponseData<UsuarioResponse>>
    {
        private readonly IRepositorioUsuario _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUsuarioCommandHandler(IRepositorioUsuario repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<UsuarioResponse>> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Verificar que exista el Id
                var usuarioValid = await _repository.GetAsync(request.Id);

                if (usuarioValid == null)
                    return new ResponseData<UsuarioResponse>(true, $"El usuario con Id: {request.Id}, no existe", null);

                // Mapear de dto a dal
                var usuario = new MapperUsuario().MapUsuario(_mapper.Map<Entities.Dtos.Usuario>(request));

                // Actualizar
                await _repository.UpdateAsync(usuario);
                // Guardar cambios
                await _unitOfWork.Commit(cancellationToken);

                // Mapear dal to dto to response
                var usuarioResponse = _mapper.Map<UsuarioResponse>(new MapperUsuario().MapUsuario(usuario));

                return new ResponseData<UsuarioResponse>(true, "", usuarioResponse);

            }
            catch (Exception ex)
            {
                return new ResponseData<UsuarioResponse>(false, $"Error USC_01. ${ex.Message}", null);
            }
        }
    }
}
