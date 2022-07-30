using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.SistemaRecurso.Commands.Update
{
    public class UpdateSistemaRecursoCommand : SistemaRecursoResponse, IRequest<ResponseData<SistemaRecursoResponse>>
    {

    }

    public class UpdateSistemaRecursoCommandHandler : IRequestHandler<UpdateSistemaRecursoCommand, ResponseData<SistemaRecursoResponse>>
    {
        private readonly IRepositorioSistemaRecurso _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSistemaRecursoCommandHandler(IRepositorioSistemaRecurso repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<SistemaRecursoResponse>> Handle(UpdateSistemaRecursoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Verificar que exista el Id
                var sistemaRecursoValid = await _repository.GetAsync(request.Id);

                if (sistemaRecursoValid == null)
                    return new ResponseData<SistemaRecursoResponse>(true, $"El sistemaRecurso con Id: {request.Id}, no existe", null);

                // Mapear de dto a dal
                var sistemaRecurso = new MapperSistemaRecurso().MapSistemaRecurso(_mapper.Map<Entities.Dtos.SistemaRecurso>(request));

                // Actualizar
                await _repository.UpdateAsync(sistemaRecurso);
                // Guardar cambios
                await _unitOfWork.Commit(cancellationToken);

                // Mapear dal to dto to response
                var sistemaRecursoResponse = _mapper.Map<SistemaRecursoResponse>(new MapperSistemaRecurso().MapSistemaRecurso(sistemaRecurso));

                return new ResponseData<SistemaRecursoResponse>(true, "", sistemaRecursoResponse);

            }
            catch (Exception ex)
            {
                return new ResponseData<SistemaRecursoResponse>(false, $"Error USC_01. ${ex.Message}", null);
            }
        }
    }
}
