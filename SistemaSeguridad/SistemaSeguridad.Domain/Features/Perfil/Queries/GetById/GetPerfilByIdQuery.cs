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

namespace SistemaSeguridad.Domain.Features.Perfil.Queries.GetById
{
    public class GetPerfilByIdQuery : IRequest<ResponseData<PerfilResponse>>
    {
        public int Id { get; set; }

        public GetPerfilByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetPerfilByIdQueryHandler : IRequestHandler<GetPerfilByIdQuery, ResponseData<PerfilResponse>>
    {
        private readonly IRepositorioPerfil _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPerfilByIdQueryHandler(IRepositorioPerfil repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<PerfilResponse>> Handle(GetPerfilByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {

            var perfil = await _repository.GetAsync(request.Id);

            if(perfil == null)
                return new ResponseData<PerfilResponse>(true, $"No existe el perfil con Id: {request.Id}", null);

            // Mapear de dal a dto -> response
            var perfilResponse = _mapper.Map<PerfilResponse>(new MapperPerfil().MapPerfil(perfil));

            return new ResponseData<PerfilResponse>(true, $"", perfilResponse);
            }
            catch (Exception ex)
            {
                return new ResponseData<PerfilResponse>(false, $"Error GSBIQ_01. {ex.Message}", null);
            }
        }
    }
}
