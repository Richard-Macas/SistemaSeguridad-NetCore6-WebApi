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

namespace SistemaSeguridad.Domain.Features.RecursoPerfil.Queries.GetById
{
    public class GetRecursoPerfilByIdQuery : IRequest<ResponseData<RecursoPerfilResponse>>
    {
        public int Id { get; set; }

        public GetRecursoPerfilByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetRecursoPerfilByIdQueryHandler : IRequestHandler<GetRecursoPerfilByIdQuery, ResponseData<RecursoPerfilResponse>>
    {
        private readonly IRepositorioRecursoPerfil _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRecursoPerfilByIdQueryHandler(IRepositorioRecursoPerfil repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<RecursoPerfilResponse>> Handle(GetRecursoPerfilByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {

            var recursoPerfil = await _repository.GetAsync(request.Id);

            if(recursoPerfil == null)
                return new ResponseData<RecursoPerfilResponse>(true, $"No existe el recursoPerfil con Id: {request.Id}", null);

            // Mapear de dal a dto -> response
            var recursoPerfilResponse = _mapper.Map<RecursoPerfilResponse>(new MapperRecursoPerfil().MapRecursoPerfil(recursoPerfil));

            return new ResponseData<RecursoPerfilResponse>(true, $"", recursoPerfilResponse);
            }
            catch (Exception ex)
            {
                return new ResponseData<RecursoPerfilResponse>(false, $"Error GSBIQ_01. {ex.Message}", null);
            }
        }
    }
}
