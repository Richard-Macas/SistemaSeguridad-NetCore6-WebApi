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

namespace SistemaSeguridad.Domain.Features.EmpresaSistema.Queries.GetById
{
    public class GetEmpresaSistemaByIdQuery : IRequest<ResponseData<EmpresaSistemaResponse>>
    {
        public int Id { get; set; }

        public GetEmpresaSistemaByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetEmpresaSistemaByIdQueryHandler : IRequestHandler<GetEmpresaSistemaByIdQuery, ResponseData<EmpresaSistemaResponse>>
    {
        private readonly IRepositorioEmpresaSistema _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetEmpresaSistemaByIdQueryHandler(IRepositorioEmpresaSistema repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<EmpresaSistemaResponse>> Handle(GetEmpresaSistemaByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {

            var empresaSistema = await _repository.GetAsync(request.Id);

            if(empresaSistema == null)
                return new ResponseData<EmpresaSistemaResponse>(true, $"No existe el empresaSistema con Id: {request.Id}", null);

            // Mapear de dal a dto -> response
            var empresaSistemaResponse = _mapper.Map<EmpresaSistemaResponse>(new MapperEmpresaSistema().MapEmpresaSistema(empresaSistema));

            return new ResponseData<EmpresaSistemaResponse>(true, $"", empresaSistemaResponse);
            }
            catch (Exception ex)
            {
                return new ResponseData<EmpresaSistemaResponse>(false, $"Error GSBIQ_01. {ex.Message}", null);
            }
        }
    }
}
