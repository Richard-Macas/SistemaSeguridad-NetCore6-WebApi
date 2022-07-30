using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.Features.UsuarioPerfil.Queries.GetById
{
    public class GetUsuarioPerfilByIdQuery : IRequest<ResponseData<UsuarioPerfilResponse>>
    {
        public int Id { get; set; }

        public GetUsuarioPerfilByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetUsuarioPerfilByIdQueryHandler : IRequestHandler<GetUsuarioPerfilByIdQuery, ResponseData<UsuarioPerfilResponse>>
    {
        private readonly IRepositorioUsuarioPerfil _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUsuarioPerfilByIdQueryHandler(IRepositorioUsuarioPerfil repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<UsuarioPerfilResponse>> Handle(GetUsuarioPerfilByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {

            var usuarioPerfil = await _repository.GetAsync(request.Id);

            if(usuarioPerfil == null)
                return new ResponseData<UsuarioPerfilResponse>(true, $"No existe el usuarioPerfil con Id: {request.Id}", null);

            // Mapear de dal a dto -> response
            var usuarioPerfilResponse = _mapper.Map<UsuarioPerfilResponse>(new MapperUsuarioPerfil().MapUsuarioPerfil(usuarioPerfil));

            return new ResponseData<UsuarioPerfilResponse>(true, $"", usuarioPerfilResponse);
            }
            catch (Exception ex)
            {
                return new ResponseData<UsuarioPerfilResponse>(false, $"Error GSBIQ_01. {ex.Message}", null);
            }
        }
    }
}
