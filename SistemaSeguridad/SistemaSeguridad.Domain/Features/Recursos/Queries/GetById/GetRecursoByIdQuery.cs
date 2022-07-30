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

namespace SistemaSeguridad.Domain.Features.Recursos.Queries.GetById
{
    public class GetRecursoByIdQuery : IRequest<ResponseData<RecursoResponse>>
    {
        public int Id { get; set; }

        public GetRecursoByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetRecursoByIdQueryHandler : IRequestHandler<GetRecursoByIdQuery, ResponseData<RecursoResponse>>
    {
        private readonly IRepositorioRecurso _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRecursoByIdQueryHandler(IRepositorioRecurso repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<RecursoResponse>> Handle(GetRecursoByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {

            var recurso = await _repository.GetAsync(request.Id);

            if(recurso == null)
                return new ResponseData<RecursoResponse>(true, $"No existe el recurso con Id: {request.Id}", null);

            // Mapear de dal a dto -> response
            var recursoResponse = _mapper.Map<RecursoResponse>(new MapperRecurso().MapRecurso(recurso));

            return new ResponseData<RecursoResponse>(true, $"", recursoResponse);
            }
            catch (Exception ex)
            {
                return new ResponseData<RecursoResponse>(false, $"Error GSBIQ_01. {ex.Message}", null);
            }
        }
    }
}
