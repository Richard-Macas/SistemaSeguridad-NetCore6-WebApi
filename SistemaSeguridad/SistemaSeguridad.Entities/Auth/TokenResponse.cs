using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaSeguridad.Entities.Auth
{
    public class TokenResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public DateTime expires_in { get; set; }
    }
}
