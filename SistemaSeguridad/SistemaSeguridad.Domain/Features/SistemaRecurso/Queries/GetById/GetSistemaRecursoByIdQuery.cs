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

namespace SistemaSeguridad.Domain.Features.SistemaRecurso.Queries.GetById
{
    public class GetSistemaRecursoByIdQuery : IRequest<ResponseData<SistemaRecursoResponse>>
    {
        public int Id { get; set; }

        public GetSistemaRecursoByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetSistemaRecursoByIdQueryHandler : IRequestHandler<GetSistemaRecursoByIdQuery, ResponseData<SistemaRecursoResponse>>
    {
        private readonly IRepositorioSistemaRecurso _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSistemaRecursoByIdQueryHandler(IRepositorioSistemaRecurso repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<SistemaRecursoResponse>> Handle(GetSistemaRecursoByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {

            var sistemaRecurso = await _repository.GetAsync(request.Id);

            if(sistemaRecurso == null)
                return new ResponseData<SistemaRecursoResponse>(true, $"No existe el sistemaRecurso con Id: {request.Id}", null);

            // Mapear de dal a dto -> response
            var sistemaRecursoResponse = _mapper.Map<SistemaRecursoResponse>(new MapperSistemaRecurso().MapSistemaRecurso(sistemaRecurso));

            return new ResponseData<SistemaRecursoResponse>(true, $"", sistemaRecursoResponse);
            }
            catch (Exception ex)
            {
                return new ResponseData<SistemaRecursoResponse>(false, $"Error GSBIQ_01. {ex.Message}", null);
            }
        }
    }
}
