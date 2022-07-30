using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.RecursoPerfil.Commands.Update
{
    public class UpdateRecursoPerfilCommand : RecursoPerfilResponse, IRequest<ResponseData<RecursoPerfilResponse>>
    {

    }

    public class UpdateRecursoPerfilCommandHandler : IRequestHandler<UpdateRecursoPerfilCommand, ResponseData<RecursoPerfilResponse>>
    {
        private readonly IRepositorioRecursoPerfil _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRecursoPerfilCommandHandler(IRepositorioRecursoPerfil repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<RecursoPerfilResponse>> Handle(UpdateRecursoPerfilCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Verificar que exista el Id
                var recursoPerfilValid = await _repository.GetAsync(request.Id);

                if (recursoPerfilValid == null)
                    return new ResponseData<RecursoPerfilResponse>(true, $"El recursoPerfil con Id: {request.Id}, no existe", null);

                // Mapear de dto a dal
                var recursoPerfil = new MapperRecursoPerfil().MapRecursoPerfil(_mapper.Map<Entities.Dtos.RecursoPerfil>(request));

                // Actualizar
                await _repository.UpdateAsync(recursoPerfil);
                // Guardar cambios
                await _unitOfWork.Commit(cancellationToken);

                // Mapear dal to dto to response
                var recursoPerfilResponse = _mapper.Map<RecursoPerfilResponse>(new MapperRecursoPerfil().MapRecursoPerfil(recursoPerfil));

                return new ResponseData<RecursoPerfilResponse>(true, "", recursoPerfilResponse);

            }
            catch (Exception ex)
            {
                return new ResponseData<RecursoPerfilResponse>(false, $"Error USC_01. ${ex.Message}", null);
            }
        }
    }
}
