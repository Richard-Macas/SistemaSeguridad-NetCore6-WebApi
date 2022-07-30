using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSeguridad.Domain.Features.UsuarioPerfil
{
    public class UsuarioPerfilResponse
    {
        public int Id { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdPerfil { get; set; }
    }
}
