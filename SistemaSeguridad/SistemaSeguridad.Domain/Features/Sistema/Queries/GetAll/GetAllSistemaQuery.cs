using AutoMapper;
using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Domain.Mapping;
using SistemaSeguridad.Entities.Dtos;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.Features.Sistema.Queries.GetAll
{
    public class GetAllSistemaQuery : IRequest<ResponseData<List<SistemaResponse>>>
    {
    }

    public class GetAllSistemaQueryHandler : IRequestHandler<GetAllSistemaQuery, ResponseData<List<SistemaResponse>>>
    {
        private readonly IRepositorioSistema _repository;
        private readonly IMapper _mapper;

        public GetAllSistemaQueryHandler(IRepositorioSistema repository)
        {
            _repository = repository;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<List<SistemaResponse>>> Handle(GetAllSistemaQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var sistemas = await _repository.GetAllAsync();

                // Mapear dal a dto
                var sistemasDto = sistemas.Select(i => new MapperSistema().MapSistema(i)).ToList();

                // Response to dto
                var sistemasResponse = sistemasDto.Select(i => _mapper.Map<SistemaResponse>(i)).ToList();

                return new ResponseData<List<SistemaResponse>>(true, "", sistemasResponse);
            }
            catch (Exception ex)
            {
                return new ResponseData<List<SistemaResponse>>(false, $"Error GASQ_01. {ex.Message}", new List<SistemaResponse>());
            }
        }
    }
}
