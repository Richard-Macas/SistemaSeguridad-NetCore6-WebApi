using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.Usuario.Commands.Create
{
    public class CreateUsuarioCommand : UsuarioResponse, IRequest<ResponseData<UsuarioResponse>>
    {

    }

    public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, ResponseData<UsuarioResponse>>
    {
        private readonly IRepositorioUsuario _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUsuarioCommandHandler(IRepositorioUsuario repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<UsuarioResponse>> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {

                // Mapear de dto a dal
                var usuario = new MapperUsuario().MapUsuario(_mapper.Map<Entities.Dtos.Usuario>(request));

                // Insertar
                await _repository.InsertAsync(usuario);
                // Guardar cambios
                await _unitOfWork.Commit(cancellationToken);

                // Mapear dal to dto
                var usuarioResponse = _mapper.Map<UsuarioResponse>(new MapperUsuario().MapUsuario(usuario));

                return new ResponseData<UsuarioResponse>(true, "", usuarioResponse);

            }
            catch (Exception ex)
            {
                return new ResponseData<UsuarioResponse>(false, $"Error CSC_01. ${ex.Message}", null);
            }
        }
    }
}
