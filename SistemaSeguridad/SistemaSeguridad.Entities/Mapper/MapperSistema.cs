using SistemaSeguridad.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal = SistemaSeguridad.Entities.Entities;

namespace SistemaSeguridad.Entities.Mapper
{
    public class MapperSistema
    {
        public MapperSistema()
        {

        }

        public Sistema MapSistema(dal.Sistema sistema)
        {
            return new Sistema
            {
                Id = sistema.Id,
                Nombre = sistema.Nombre,
                Dominio = sistema.Dominio,
                Subdominio = sistema.Subdominio,
                EstaHabilitado = sistema.EstaHabilitado,
            };
        }

        public dal.Sistema MapSistema(Sistema sistema)
        {
            return new dal.Sistema
            {
                Id = sistema.Id,
                Nombre = sistema.Nombre,
                Dominio = sistema.Dominio,
                Subdominio = sistema.Subdominio,
                EstaHabilitado = sistema.EstaHabilitado,
            };
        }
    }
}
