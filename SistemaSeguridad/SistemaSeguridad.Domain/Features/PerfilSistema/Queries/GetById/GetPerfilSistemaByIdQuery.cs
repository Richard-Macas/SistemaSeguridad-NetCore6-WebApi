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

namespace SistemaSeguridad.Domain.Features.PerfilSistema.Queries.GetById
{
    public class GetPerfilSistemaByIdQuery : IRequest<ResponseData<PerfilSistemaResponse>>
    {
        public int Id { get; set; }

        public GetPerfilSistemaByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetPerfilSistemaByIdQueryHandler : IRequestHandler<GetPerfilSistemaByIdQuery, ResponseData<PerfilSistemaResponse>>
    {
        private readonly IRepositorioPerfilSistema _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPerfilSistemaByIdQueryHandler(IRepositorioPerfilSistema repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<PerfilSistemaResponse>> Handle(GetPerfilSistemaByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {

            var perfilSistema = await _repository.GetAsync(request.Id);

            if(perfilSistema == null)
                return new ResponseData<PerfilSistemaResponse>(true, $"No existe el perfilSistema con Id: {request.Id}", null);

            // Mapear de dal a dto -> response
            var perfilSistemaResponse = _mapper.Map<PerfilSistemaResponse>(new MapperPerfilSistema().MapPerfilSistema(perfilSistema));

            return new ResponseData<PerfilSistemaResponse>(true, $"", perfilSistemaResponse);
            }
            catch (Exception ex)
            {
                return new ResponseData<PerfilSistemaResponse>(false, $"Error GSBIQ_01. {ex.Message}", null);
            }
        }
    }
}
