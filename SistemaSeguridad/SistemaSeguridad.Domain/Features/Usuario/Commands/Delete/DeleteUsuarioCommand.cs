using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.Features.Usuario.Commands.Delete
{
    public class DeleteUsuarioCommand : IRequest<ResponseData<int>>
    {
        public int Id { get; set; }

        public DeleteUsuarioCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteUsuarioCommandHandler : IRequestHandler<DeleteUsuarioCommand, ResponseData<int>>
    {
        private readonly IRepositorioUsuario _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUsuarioCommandHandler(IRepositorioUsuario repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseData<int>> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var validExiste = await _repository.GetAsync(request.Id);

                // Validar que exista el usuario
                if (validExiste == null)
                    return new ResponseData<int>(true, $"No existe el usuario con Id: {validExiste.Id}", 0);

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
