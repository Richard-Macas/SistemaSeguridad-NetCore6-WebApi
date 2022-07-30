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

namespace SistemaSeguridad.Domain.Features.Sistema.Queries.GetById
{
    public class GetSistemaByIdQuery : IRequest<ResponseData<SistemaResponse>>
    {
        public int Id { get; set; }

        public GetSistemaByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetSistemaByIdQueryHandler : IRequestHandler<GetSistemaByIdQuery, ResponseData<SistemaResponse>>
    {
        private readonly IRepositorioSistema _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSistemaByIdQueryHandler(IRepositorioSistema repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<SistemaResponse>> Handle(GetSistemaByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {

            var sistema = await _repository.GetAsync(request.Id);

            if(sistema == null)
                return new ResponseData<SistemaResponse>(true, $"No existe el sistema con Id: {request.Id}", null);

            // Mapear de dal a dto -> response
            var sistemaResponse = _mapper.Map<SistemaResponse>(new MapperSistema().MapSistema(sistema));

            return new ResponseData<SistemaResponse>(true, $"", sistemaResponse);
            }
            catch (Exception ex)
            {
                return new ResponseData<SistemaResponse>(false, $"Error GSBIQ_01. {ex.Message}", null);
            }
        }
    }
}
