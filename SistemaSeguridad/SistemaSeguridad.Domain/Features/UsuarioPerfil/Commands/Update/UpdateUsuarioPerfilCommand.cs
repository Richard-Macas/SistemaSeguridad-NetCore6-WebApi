using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.UsuarioPerfil.Commands.Update
{
    public class UpdateUsuarioPerfilCommand : UsuarioPerfilResponse, IRequest<ResponseData<UsuarioPerfilResponse>>
    {

    }

    public class UpdateUsuarioPerfilCommandHandler : IRequestHandler<UpdateUsuarioPerfilCommand, ResponseData<UsuarioPerfilResponse>>
    {
        private readonly IRepositorioUsuarioPerfil _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUsuarioPerfilCommandHandler(IRepositorioUsuarioPerfil repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<UsuarioPerfilResponse>> Handle(UpdateUsuarioPerfilCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Verificar que exista el Id
                var usuarioPerfilValid = await _repository.GetAsync(request.Id);

                if (usuarioPerfilValid == null)
                    return new ResponseData<UsuarioPerfilResponse>(true, $"El usuarioPerfil con Id: {request.Id}, no existe", null);

                // Mapear de dto a dal
                var usuarioPerfil = new MapperUsuarioPerfil().MapUsuarioPerfil(_mapper.Map<Entities.Dtos.UsuarioPerfil>(request));

                // Actualizar
                await _repository.UpdateAsync(usuarioPerfil);
                // Guardar cambios
                await _unitOfWork.Commit(cancellationToken);

                // Mapear dal to dto to response
                var usuarioPerfilResponse = _mapper.Map<UsuarioPerfilResponse>(new MapperUsuarioPerfil().MapUsuarioPerfil(usuarioPerfil));

                return new ResponseData<UsuarioPerfilResponse>(true, "", usuarioPerfilResponse);

            }
            catch (Exception ex)
            {
                return new ResponseData<UsuarioPerfilResponse>(false, $"Error USC_01. ${ex.Message}", null);
            }
        }
    }
}
