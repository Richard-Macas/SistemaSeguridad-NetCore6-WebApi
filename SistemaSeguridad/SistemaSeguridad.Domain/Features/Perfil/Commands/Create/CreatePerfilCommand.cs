using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.Perfil.Commands.Create
{
    public class CreatePerfilCommand : PerfilResponse, IRequest<ResponseData<PerfilResponse>>
    {

    }

    public class CreatePerfilCommandHandler : IRequestHandler<CreatePerfilCommand, ResponseData<PerfilResponse>>
    {
        private readonly IRepositorioPerfil _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePerfilCommandHandler(IRepositorioPerfil repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<PerfilResponse>> Handle(CreatePerfilCommand request, CancellationToken cancellationToken)
        {
            try
            {

                // Mapear de dto a dal
                var perfil = new MapperPerfil().MapPerfil(_mapper.Map<Entities.Dtos.Perfil>(request));

                // Insertar
                await _repository.InsertAsync(perfil);
                // Guardar cambios
                await _unitOfWork.Commit(cancellationToken);

                // Mapear dal to dto
                var perfilResponse = _mapper.Map<PerfilResponse>(new MapperPerfil().MapPerfil(perfil));

                return new ResponseData<PerfilResponse>(true, "", perfilResponse);

            }
            catch (Exception ex)
            {
                return new ResponseData<PerfilResponse>(false, $"Error CSC_01. ${ex.Message}", null);
            }
        }
    }
}
