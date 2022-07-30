using SistemaSeguridad.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal = SistemaSeguridad.Entities.Entities;

namespace SistemaSeguridad.Entities.Mapper
{
    public class MapperEmpresaSistema
    {
        public MapperEmpresaSistema()
        {

        }

        public EmpresaSistema MapEmpresaSistema(dal.EmpresaSistema empresaSistema)
        {
            return new EmpresaSistema
            {
                Id = empresaSistema.Id,
                IdSistema = empresaSistema.IdSistema,
                IdEmpresa = empresaSistema.IdEmpresa,
                EstaHabilitado = empresaSistema.EstaHabilitado,
            };
        }

        public dal.EmpresaSistema MapEmpresaSistema(EmpresaSistema empresaSistema)
        {
            return new dal.EmpresaSistema
            {
                Id = empresaSistema.Id,
                IdSistema = empresaSistema.IdSistema,
                IdEmpresa = empresaSistema.IdEmpresa,
                EstaHabilitado = empresaSistema.EstaHabilitado,
            };
        }
    }
}
