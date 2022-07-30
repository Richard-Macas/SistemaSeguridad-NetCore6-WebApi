using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.UsuarioPerfil.Commands.Create
{
    public class CreateUsuarioPerfilCommand : UsuarioPerfilResponse, IRequest<ResponseData<UsuarioPerfilResponse>>
    {

    }

    public class CreateUsuarioPerfilCommandHandler : IRequestHandler<CreateUsuarioPerfilCommand, ResponseData<UsuarioPerfilResponse>>
    {
        private readonly IRepositorioUsuarioPerfil _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUsuarioPerfilCommandHandler(IRepositorioUsuarioPerfil repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<UsuarioPerfilResponse>> Handle(CreateUsuarioPerfilCommand request, CancellationToken cancellationToken)
        {
            try
            {

                // Mapear de dto a dal
                var usuarioPerfil = new MapperUsuarioPerfil().MapUsuarioPerfil(_mapper.Map<Entities.Dtos.UsuarioPerfil>(request));

                // Insertar
                await _repository.InsertAsync(usuarioPerfil);
                // Guardar cambios
                await _unitOfWork.Commit(cancellationToken);

                // Mapear dal to dto
                var usuarioPerfilResponse = _mapper.Map<UsuarioPerfilResponse>(new MapperUsuarioPerfil().MapUsuarioPerfil(usuarioPerfil));

                return new ResponseData<UsuarioPerfilResponse>(true, "", usuarioPerfilResponse);

            }
            catch (Exception ex)
            {
                return new ResponseData<UsuarioPerfilResponse>(false, $"Error CSC_01. ${ex.Message}", null);
            }
        }
    }
}
