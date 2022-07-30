using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.SistemaRecurso.Commands.Create
{
    public class CreateSistemaRecursoCommand : SistemaRecursoResponse, IRequest<ResponseData<SistemaRecursoResponse>>
    {

    }

    public class CreateSistemaRecursoCommandHandler : IRequestHandler<CreateSistemaRecursoCommand, ResponseData<SistemaRecursoResponse>>
    {
        private readonly IRepositorioSistemaRecurso _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSistemaRecursoCommandHandler(IRepositorioSistemaRecurso repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<SistemaRecursoResponse>> Handle(CreateSistemaRecursoCommand request, CancellationToken cancellationToken)
        {
            try
            {

                // Mapear de dto a dal
                var sistemaRecurso = new MapperSistemaRecurso().MapSistemaRecurso(_mapper.Map<Entities.Dtos.SistemaRecurso>(request));

                // Insertar
                await _repository.InsertAsync(sistemaRecurso);
                // Guardar cambios
                await _unitOfWork.Commit(cancellationToken);

                // Mapear dal to dto
                var sistemaRecursoResponse = _mapper.Map<SistemaRecursoResponse>(new MapperSistemaRecurso().MapSistemaRecurso(sistemaRecurso));

                return new ResponseData<SistemaRecursoResponse>(true, "", sistemaRecursoResponse);

            }
            catch (Exception ex)
            {
                return new ResponseData<SistemaRecursoResponse>(false, $"Error CSC_01. ${ex.Message}", null);
            }
        }
    }
}
