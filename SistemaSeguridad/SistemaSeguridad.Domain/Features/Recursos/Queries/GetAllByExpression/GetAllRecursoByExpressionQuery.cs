using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Entities.Dtos;
using SistemaSeguridad.Entities.Dtos.RecursoHelpers;
using SistemaSeguridad.Entities.Mapper;
using SistemaSeguridad.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.Features.Sistema.Queries.GetAllByExpression
{
    public class GetAllRecursoByExpressionQuery : IRequest<ResponseData<List<RecursoPadre>>>
    {
        public ClaimsPrincipal usuario { get; set; }
        public int idSistema { get; set; }

        public GetAllRecursoByExpressionQuery(ClaimsPrincipal _usuario, int _idSistema)
        {
            usuario = _usuario;
            idSistema = _idSistema;
        }
    }

    public class GetAllRecursoByExpressionQueryHandler : IRequestHandler<GetAllRecursoByExpressionQuery, ResponseData<List<RecursoPadre>>>
    {
        private readonly IRepositorioRecurso _repository;
        private readonly IRepositorioSistema _repositorySis;

        public GetAllRecursoByExpressionQueryHandler(IRepositorioRecurso repository, IRepositorioSistema repositorySis)
        {
            _repository = repository;
            _repositorySis = repositorySis;
        }

        public async Task<ResponseData<List<RecursoPadre>>> Handle(GetAllRecursoByExpressionQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Se valida que el id sistema exista
                var validSistema = await _repositorySis.GetAsync(request.idSistema);

                if(validSistema == null)
                    new ResponseData<List<RecursoPadre>>(true, $"El sistema con identificador: {request.idSistema} no existe", null);

                var usuarioDataLogin = request.usuario;

                // Obtener los roles del usuario
                var roles = usuarioDataLogin.FindAll(x => x.Type.Contains("role")).Select(x => x.Value).ToList();

                // Buscar los recurso que coincidan con los roles asignado al usuario
                var recursosPadres = await _repository.GetAll(x => x.SistemaRecursos.Where(x => x.IdSistema == request.idSistema && x.IdSistemaNavigation.EstaHabilitado == true).Count() > 0
                                                               && x.EstaHabilitado == true
                                                               && x.RecursoPerfils.Where(p => roles.Any(l => p.IdPerfilNavigation.Nombre == l) && p.EstaHabilitado == true).Count() > 0
                                                            );

                // Crear la estrucutra padre - hijos
                List<RecursoPadre> listRecursosPadres = new List<RecursoPadre>();

                foreach (var recursoPadre in recursosPadres)
                {
                    // Obtener los hijos del recurso padre que pertenezcan al perfil
                    var subrecursos = await _repository.GetAll(x => x.IdPadre == recursoPadre.Id
                                                            && x.EstaHabilitado == true
                                                            );

                    // Estructurar recursos hijos
                    var listSubrecursos = subrecursos.Select(x => {
                        return new Subrecurso()
                        {
                            Descripcion = x.Descripcion,
                            Icono = x.Icono,
                            URLPath = x.URLPath,
                        };
                    }).OrderBy(x => x.Descripcion)
                    .GroupBy(x => x.Descripcion).Select(y => y.First()).ToList();

                    // Crear recurso padre con hijos y añador a la lista
                    listRecursosPadres.Add(new RecursoPadre()
                    {
                        Descripcion = recursoPadre.Descripcion,
                        URLPath = recursoPadre.URLPath,
                        Icono = recursoPadre.Icono,
                        Subrecursos = listSubrecursos
                    });
                }

                // Ordenar recursos padres por descripción
                listRecursosPadres.OrderBy(x => x.Descripcion).ToList();

                return new ResponseData<List<RecursoPadre>>(true, "", listRecursosPadres);
            }
            catch (Exception ex)
            {
                return new ResponseData<List<RecursoPadre>>(false, $"Error GAPRBEQ_01. {ex.Message}", null);
            }
        }
    }
}
