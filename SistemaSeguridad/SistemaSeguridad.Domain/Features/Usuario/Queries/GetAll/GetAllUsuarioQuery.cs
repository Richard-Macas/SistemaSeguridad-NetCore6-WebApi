using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.Usuario.Queries.GetAll
{
    public class GetAllUsuarioQuery : IRequest<ResponseData<List<UsuarioResponse>>>
    {
    }

    public class GetAllUsuarioQueryHandler : IRequestHandler<GetAllUsuarioQuery, ResponseData<List<UsuarioResponse>>>
    {
        private readonly IRepositorioUsuario _repository;
        private readonly IMapper _mapper;

        public GetAllUsuarioQueryHandler(IRepositorioUsuario repository)
        {
            _repository = repository;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<List<UsuarioResponse>>> Handle(GetAllUsuarioQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var usuarios = await _repository.GetAllAsync();

                // Mapear dal a dto
                var usuariosDto = usuarios.Select(i => new MapperUsuario().MapUsuario(i)).ToList();

                // Response to dto
                var usuariosResponse = usuariosDto.Select(i => _mapper.Map<UsuarioResponse>(i)).ToList();

                return new ResponseData<List<UsuarioResponse>>(true, "", usuariosResponse);
            }
            catch (Exception ex)
            {
                return new ResponseData<List<UsuarioResponse>>(false, $"Error GASQ_01. {ex.Message}", new List<UsuarioResponse>());
            }
        }
    }
}
