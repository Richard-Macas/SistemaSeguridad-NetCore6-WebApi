using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.Perfil.Commands.Update
{
    public class UpdatePerfilCommand : PerfilResponse, IRequest<ResponseData<PerfilResponse>>
    {

    }

    public class UpdatePerfilCommandHandler : IRequestHandler<UpdatePerfilCommand, ResponseData<PerfilResponse>>
    {
        private readonly IRepositorioPerfil _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePerfilCommandHandler(IRepositorioPerfil repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<PerfilResponse>> Handle(UpdatePerfilCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Verificar que exista el Id
                var perfilValid = await _repository.GetAsync(request.Id);

                if (perfilValid == null)
                    return new ResponseData<PerfilResponse>(true, $"El perfil con Id: {request.Id}, no existe", null);

                // Mapear de dto a dal
                var perfil = new MapperPerfil().MapPerfil(_mapper.Map<Entities.Dtos.Perfil>(request));

                // Actualizar
                await _repository.UpdateAsync(perfil);
                // Guardar cambios
                await _unitOfWork.Commit(cancellationToken);

                // Mapear dal to dto to response
                var perfilResponse = _mapper.Map<PerfilResponse>(new MapperPerfil().MapPerfil(perfil));

                return new ResponseData<PerfilResponse>(true, "", perfilResponse);

            }
            catch (Exception ex)
            {
                return new ResponseData<PerfilResponse>(false, $"Error USC_01. ${ex.Message}", null);
            }
        }
    }
}
