using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;

namespace SistemaSeguridad.Domain.Features.UsuarioPerfil.Queries.GetAll
{
    public class GetAllUsuarioPerfilQuery : IRequest<ResponseData<List<UsuarioPerfilResponse>>>
    {
    }

    public class GetAllUsuarioPerfilQueryHandler : IRequestHandler<GetAllUsuarioPerfilQuery, ResponseData<List<UsuarioPerfilResponse>>>
    {
        private readonly IRepositorioUsuarioPerfil _repository;
        private readonly IMapper _mapper;

        public GetAllUsuarioPerfilQueryHandler(IRepositorioUsuarioPerfil repository)
        {
            _repository = repository;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<List<UsuarioPerfilResponse>>> Handle(GetAllUsuarioPerfilQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var usuarioPerfils = await _repository.GetAllAsync();

                // Mapear dal a dto
                var usuarioPerfilsDto = usuarioPerfils.Select(i => new MapperUsuarioPerfil().MapUsuarioPerfil(i)).ToList();

                // Response to dto
                var usuarioPerfilsResponse = usuarioPerfilsDto.Select(i => _mapper.Map<UsuarioPerfilResponse>(i)).ToList();

                return new ResponseData<List<UsuarioPerfilResponse>>(true, "", usuarioPerfilsResponse);
            }
            catch (Exception ex)
            {
                return new ResponseData<List<UsuarioPerfilResponse>>(false, $"Error GASQ_01. {ex.Message}", new List<UsuarioPerfilResponse>());
            }
        }
    }
}
