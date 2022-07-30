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

namespace SistemaSeguridad.Domain.Features.Usuario.Queries.GetById
{
    public class GetUsuarioByIdQuery : IRequest<ResponseData<UsuarioResponse>>
    {
        public int Id { get; set; }

        public GetUsuarioByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetUsuarioByIdQueryHandler : IRequestHandler<GetUsuarioByIdQuery, ResponseData<UsuarioResponse>>
    {
        private readonly IRepositorioUsuario _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUsuarioByIdQueryHandler(IRepositorioUsuario repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<UsuarioResponse>> Handle(GetUsuarioByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {

            var usuario = await _repository.GetAsync(request.Id);

            if(usuario == null)
                return new ResponseData<UsuarioResponse>(true, $"No existe el usuario con Id: {request.Id}", null);

            // Mapear de dal a dto -> response
            var usuarioResponse = _mapper.Map<UsuarioResponse>(new MapperUsuario().MapUsuario(usuario));

            return new ResponseData<UsuarioResponse>(true, $"", usuarioResponse);
            }
            catch (Exception ex)
            {
                return new ResponseData<UsuarioResponse>(false, $"Error GSBIQ_01. {ex.Message}", null);
            }
        }
    }
}
