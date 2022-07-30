using SistemaSeguridad.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal = SistemaSeguridad.Entities.Entities;

namespace SistemaSeguridad.Entities.Mapper
{
    public class MapperEmpresa
    {
        public MapperEmpresa()
        {

        }

        public Empresa MapEmpresa(dal.Empresa empresa)
        {
            return new Empresa
            {
                Id = empresa.Id,
                IdPortal = empresa.IdPortal,
                Empresa1 = empresa.Empresa1,
                CorreoAdministrador = empresa.CorreoAdministrador,
                TelefonoAdministrador = empresa.TelefonoAdministrador,
                Dominio = empresa.Dominio,
                EstaHabilitado = empresa.EstaHabilitado,
            };
        }

        public dal.Empresa MapEmpresa(Empresa empresa)
        {
            return new dal.Empresa
            {
                Id = empresa.Id,
                IdPortal = empresa.IdPortal,
                Empresa1 = empresa.Empresa1,
                CorreoAdministrador = empresa.CorreoAdministrador,
                TelefonoAdministrador = empresa.TelefonoAdministrador,
                Dominio = empresa.Dominio,
                EstaHabilitado = empresa.EstaHabilitado,
            };
        }
    }
}
