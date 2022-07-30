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

namespace SistemaSeguridad.Domain.Features.Portal.Queries.GetById
{
    public class GetPortalByIdQuery : IRequest<ResponseData<PortalResponse>>
    {
        public int Id { get; set; }

        public GetPortalByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetPortalByIdQueryHandler : IRequestHandler<GetPortalByIdQuery, ResponseData<PortalResponse>>
    {
        private readonly IRepositorioPortal _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPortalByIdQueryHandler(IRepositorioPortal repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<PortalResponse>> Handle(GetPortalByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {

            var portal = await _repository.GetAsync(request.Id);

            if(portal == null)
                return new ResponseData<PortalResponse>(true, $"No existe el portal con Id: {request.Id}", null);

            // Mapear de dal a dto -> response
            var portalResponse = _mapper.Map<PortalResponse>(new MapperPortal().MapPortal(portal));

            return new ResponseData<PortalResponse>(true, $"", portalResponse);
            }
            catch (Exception ex)
            {
                return new ResponseData<PortalResponse>(false, $"Error GSBIQ_01. {ex.Message}", null);
            }
        }
    }
}
