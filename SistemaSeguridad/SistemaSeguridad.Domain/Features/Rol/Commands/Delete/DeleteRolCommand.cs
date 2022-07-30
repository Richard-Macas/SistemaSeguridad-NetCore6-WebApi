using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.Features.Rol.Commands.Delete
{
    public class DeleteRolCommand : IRequest<ResponseData<int>>
    {
        public int Id { get; set; }

        public DeleteRolCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteRolCommandHandler : IRequestHandler<DeleteRolCommand, ResponseData<int>>
    {
        private readonly IRepositorioRol _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRolCommandHandler(IRepositorioRol repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseData<int>> Handle(DeleteRolCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var validExiste = await _repository.GetAsync(request.Id);

                // Validar que exista el rol
                if (validExiste == null)
                    return new ResponseData<int>(true, $"No existe el rol con Id: {validExiste.Id}", 0);

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
