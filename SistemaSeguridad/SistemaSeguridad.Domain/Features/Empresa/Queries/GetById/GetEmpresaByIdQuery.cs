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

namespace SistemaSeguridad.Domain.Features.Empresa.Queries.GetById
{
    public class GetEmpresaByIdQuery : IRequest<ResponseData<EmpresaResponse>>
    {
        public int Id { get; set; }

        public GetEmpresaByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetEmpresaByIdQueryHandler : IRequestHandler<GetEmpresaByIdQuery, ResponseData<EmpresaResponse>>
    {
        private readonly IRepositorioEmpresa _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetEmpresaByIdQueryHandler(IRepositorioEmpresa repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<EmpresaResponse>> Handle(GetEmpresaByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {

            var empresa = await _repository.GetAsync(request.Id);

            if(empresa == null)
                return new ResponseData<EmpresaResponse>(true, $"No existe el empresa con Id: {request.Id}", null);

            // Mapear de dal a dto -> response
            var empresaResponse = _mapper.Map<EmpresaResponse>(new MapperEmpresa().MapEmpresa(empresa));

            return new ResponseData<EmpresaResponse>(true, $"", empresaResponse);
            }
            catch (Exception ex)
            {
                return new ResponseData<EmpresaResponse>(false, $"Error GSBIQ_01. {ex.Message}", null);
            }
        }
    }
}
