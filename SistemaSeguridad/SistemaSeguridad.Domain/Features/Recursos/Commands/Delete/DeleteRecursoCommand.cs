using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.Features.Recursos.Commands.Delete
{
    public class DeleteRecursoCommand : IRequest<ResponseData<int>>
    {
        public int Id { get; set; }

        public DeleteRecursoCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteRecursoCommandHandler : IRequestHandler<DeleteRecursoCommand, ResponseData<int>>
    {
        private readonly IRepositorioRecurso _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRecursoCommandHandler(IRepositorioRecurso repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseData<int>> Handle(DeleteRecursoCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var validExiste = await _repository.GetAsync(request.Id);

                // Validar que exista el recurso
                if (validExiste == null)
                    return new ResponseData<int>(true, $"No existe el recurso con Id: {validExiste.Id}", 0);

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
