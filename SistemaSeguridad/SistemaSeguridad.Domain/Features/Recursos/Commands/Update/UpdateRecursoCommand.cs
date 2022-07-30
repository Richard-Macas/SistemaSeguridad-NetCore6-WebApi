using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.Recursos.Commands.Update
{
    public class UpdateRecursoCommand : RecursoResponse, IRequest<ResponseData<RecursoResponse>>
    {

    }

    public class UpdateRecursoCommandHandler : IRequestHandler<UpdateRecursoCommand, ResponseData<RecursoResponse>>
    {
        private readonly IRepositorioRecurso _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRecursoCommandHandler(IRepositorioRecurso repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<RecursoResponse>> Handle(UpdateRecursoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Verificar que exista el Id
                var recursoValid = await _repository.GetAsync(request.Id);

                if (recursoValid == null)
                    return new ResponseData<RecursoResponse>(true, $"El recurso con Id: {request.Id}, no existe", null);

                // Mapear de dto a dal
                var recurso = new MapperRecurso().MapRecurso(_mapper.Map<Entities.Dtos.Recurso>(request));

                // Actualizar
                await _repository.UpdateAsync(recurso);
                // Guardar cambios
                await _unitOfWork.Commit(cancellationToken);

                // Mapear dal to dto to response
                var recursoResponse = _mapper.Map<RecursoResponse>(new MapperRecurso().MapRecurso(recurso));

                return new ResponseData<RecursoResponse>(true, "", recursoResponse);

            }
            catch (Exception ex)
            {
                return new ResponseData<RecursoResponse>(false, $"Error USC_01. ${ex.Message}", null);
            }
        }
    }
}
