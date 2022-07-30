using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.Recursos.Commands.Create
{
    public class CreateRecursoCommand : RecursoResponse, IRequest<ResponseData<RecursoResponse>>
    {

    }

    public class CreateRecursoCommandHandler : IRequestHandler<CreateRecursoCommand, ResponseData<RecursoResponse>>
    {
        private readonly IRepositorioRecurso _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateRecursoCommandHandler(IRepositorioRecurso repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<RecursoResponse>> Handle(CreateRecursoCommand request, CancellationToken cancellationToken)
        {
            try
            {

                // Mapear de dto a dal
                var recurso = new MapperRecurso().MapRecurso(_mapper.Map<Entities.Dtos.Recurso>(request));

                // Insertar
                await _repository.InsertAsync(recurso);
                // Guardar cambios
                await _unitOfWork.Commit(cancellationToken);

                // Mapear dal to dto
                var recursoResponse = _mapper.Map<RecursoResponse>(new MapperRecurso().MapRecurso(recurso));

                return new ResponseData<RecursoResponse>(true, "", recursoResponse);

            }
            catch (Exception ex)
            {
                return new ResponseData<RecursoResponse>(false, $"Error CSC_01. ${ex.Message}", null);
            }
        }
    }
}
