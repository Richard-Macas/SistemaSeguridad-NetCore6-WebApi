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

namespace SistemaSeguridad.Domain.Features.Rol.Queries.GetById
{
    public class GetRolByIdQuery : IRequest<ResponseData<RolResponse>>
    {
        public int Id { get; set; }

        public GetRolByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetRolByIdQueryHandler : IRequestHandler<GetRolByIdQuery, ResponseData<RolResponse>>
    {
        private readonly IRepositorioRol _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRolByIdQueryHandler(IRepositorioRol repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseData<RolResponse>> Handle(GetRolByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {

            var rol = await _repository.GetAsync(request.Id);

            if(rol == null)
                return new ResponseData<RolResponse>(true, $"No existe el rol con Id: {request.Id}", null);

            // Mapear de dal a dto -> response
            var rolResponse = _mapper.Map<RolResponse>(new MapperRol().MapRol(rol));

            return new ResponseData<RolResponse>(true, $"", rolResponse);
            }
            catch (Exception ex)
            {
                return new ResponseData<RolResponse>(false, $"Error GSBIQ_01. {ex.Message}", null);
            }
        }
    }
}
