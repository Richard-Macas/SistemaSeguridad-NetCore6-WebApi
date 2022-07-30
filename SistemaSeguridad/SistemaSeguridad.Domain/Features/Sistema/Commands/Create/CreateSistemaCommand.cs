using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.Sistema.Commands.Create
{
    public class CreateSistemaCommand : SistemaResponse, IRequest<ResponseData<SistemaResponse>>
    {

    }

    public class CreateSistemaCommandHandler : IRequestHandler<CreateSistemaCommand, ResponseData<SistemaResponse>>
    {
        private readonly IRepositorioSistema _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSistemaCommandHandler(IRepositorioSistema repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<SistemaResponse>> Handle(CreateSistemaCommand request, CancellationToken cancellationToken)
        {
            try
            {

                // Mapear de dto a dal
                var sistema = new MapperSistema().MapSistema(_mapper.Map<Entities.Dtos.Sistema>(request));

                // Insertar
                await _repository.InsertAsync(sistema);
                // Guardar cambios
                await _unitOfWork.Commit(cancellationToken);

                // Mapear dal to dto
                var sistemaResponse = _mapper.Map<SistemaResponse>(new MapperSistema().MapSistema(sistema));

                return new ResponseData<SistemaResponse>(true, "", sistemaResponse);

            }
            catch (Exception ex)
            {
                return new ResponseData<SistemaResponse>(false, $"Error CSC_01. ${ex.Message}", null);
            }
        }
    }
}
