using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.RecursoPerfil.Commands.Create
{
    public class CreateRecursoPerfilCommand : RecursoPerfilResponse, IRequest<ResponseData<RecursoPerfilResponse>>
    {

    }

    public class CreateRecursoPerfilCommandHandler : IRequestHandler<CreateRecursoPerfilCommand, ResponseData<RecursoPerfilResponse>>
    {
        private readonly IRepositorioRecursoPerfil _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateRecursoPerfilCommandHandler(IRepositorioRecursoPerfil repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<RecursoPerfilResponse>> Handle(CreateRecursoPerfilCommand request, CancellationToken cancellationToken)
        {
            try
            {

                // Mapear de dto a dal
                var recursoPerfil = new MapperRecursoPerfil().MapRecursoPerfil(_mapper.Map<Entities.Dtos.RecursoPerfil>(request));

                // Insertar
                await _repository.InsertAsync(recursoPerfil);
                // Guardar cambios
                await _unitOfWork.Commit(cancellationToken);

                // Mapear dal to dto
                var recursoPerfilResponse = _mapper.Map<RecursoPerfilResponse>(new MapperRecursoPerfil().MapRecursoPerfil(recursoPerfil));

                return new ResponseData<RecursoPerfilResponse>(true, "", recursoPerfilResponse);

            }
            catch (Exception ex)
            {
                return new ResponseData<RecursoPerfilResponse>(false, $"Error CSC_01. ${ex.Message}", null);
            }
        }
    }
}
