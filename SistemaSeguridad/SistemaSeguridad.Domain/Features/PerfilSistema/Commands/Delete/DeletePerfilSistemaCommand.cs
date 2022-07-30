using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.Features.PerfilSistema.Commands.Delete
{
    public class DeletePerfilSistemaCommand : IRequest<ResponseData<int>>
    {
        public int Id { get; set; }

        public DeletePerfilSistemaCommand(int id)
        {
            Id = id;
        }
    }

    public class DeletePerfilSistemaCommandHandler : IRequestHandler<DeletePerfilSistemaCommand, ResponseData<int>>
    {
        private readonly IRepositorioPerfilSistema _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePerfilSistemaCommandHandler(IRepositorioPerfilSistema repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseData<int>> Handle(DeletePerfilSistemaCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var validExiste = await _repository.GetAsync(request.Id);

                // Validar que exista el perfilSistema
                if (validExiste == null)
                    return new ResponseData<int>(true, $"No existe el perfilSistema con Id: {validExiste.Id}", 0);

                await _repository.DeleteAsync(validExiste);
                await _unitOfWork.Commit(cancellationToken);

                return new ResponseData<int>(true, $"", validExiste.Id);
            }
            catch (Exception ex)
            {
                return new ResponseData<int>(false, $"Error DSC_01. {ex.Message}", 0);
            }
        }
    }
}
