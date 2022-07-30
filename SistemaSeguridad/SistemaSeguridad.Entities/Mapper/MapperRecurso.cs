using SistemaSeguridad.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal = SistemaSeguridad.Entities.Entities;

namespace SistemaSeguridad.Entities.Mapper
{
    public class MapperRecurso
    {
        public MapperRecurso()
        {

        }

        public Recurso MapRecurso(dal.Recurso recurso)
        {
            return new Recurso
            {
                Id = recurso.Id,
                Nivel = recurso.Nivel,
                Descripcion = recurso.Descripcion,
                IdPadre = recurso.IdPadre,
                URLPath = recurso.URLPath,
                Icono = recurso.Icono,
                EstaHabilitado = recurso.EstaHabilitado,
            };
        }

        public dal.Recurso MapRecurso(Recurso recurso)
        {
            return new dal.Recurso
            {
                Id = recurso.Id,
                Nivel = recurso.Nivel,
                Descripcion = recurso.Descripcion,
                IdPadre = recurso.IdPadre,
                URLPath = recurso.URLPath,
                Icono = recurso.Icono,
                EstaHabilitado = recurso.EstaHabilitado,
            };
        }
    }
}
