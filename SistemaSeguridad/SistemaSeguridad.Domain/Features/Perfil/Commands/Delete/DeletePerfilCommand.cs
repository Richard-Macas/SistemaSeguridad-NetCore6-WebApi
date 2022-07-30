using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.Features.Perfil.Commands.Delete
{
    public class DeletePerfilCommand : IRequest<ResponseData<int>>
    {
        public int Id { get; set; }

        public DeletePerfilCommand(int id)
        {
            Id = id;
        }
    }

    public class DeletePerfilCommandHandler : IRequestHandler<DeletePerfilCommand, ResponseData<int>>
    {
        private readonly IRepositorioPerfil _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePerfilCommandHandler(IRepositorioPerfil repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseData<int>> Handle(DeletePerfilCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var validExiste = await _repository.GetAsync(request.Id);

                // Validar que exista el perfil
                if (validExiste == null)
                    return new ResponseData<int>(true, $"No existe el perfil con Id: {validExiste.Id}", 0);

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
