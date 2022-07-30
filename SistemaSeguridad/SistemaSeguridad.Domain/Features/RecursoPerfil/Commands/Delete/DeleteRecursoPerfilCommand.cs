using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.Features.RecursoPerfil.Commands.Delete
{
    public class DeleteRecursoPerfilCommand : IRequest<ResponseData<int>>
    {
        public int Id { get; set; }

        public DeleteRecursoPerfilCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteRecursoPerfilCommandHandler : IRequestHandler<DeleteRecursoPerfilCommand, ResponseData<int>>
    {
        private readonly IRepositorioRecursoPerfil _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRecursoPerfilCommandHandler(IRepositorioRecursoPerfil repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseData<int>> Handle(DeleteRecursoPerfilCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var validExiste = await _repository.GetAsync(request.Id);

                // Validar que exista el recursoPerfil
                if (validExiste == null)
                    return new ResponseData<int>(true, $"No existe el recursoPerfil con Id: {validExiste.Id}", 0);

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
