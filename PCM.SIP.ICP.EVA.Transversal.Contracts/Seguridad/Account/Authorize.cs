using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Transversal.Contracts.Seguridad.Account
{
    public class AuthorizeRequest
    {
        public string? idsession { get; set; }
        public string? codigo_perfil { get; set; }
    }

    public class AuthorizeResponse
    {
        public string? token { get; set; }
        public string? nombrecompleto { get; set; }
        public string? username { get; set; }
        public string? perfil { get; set; }
        public string? numdocumento { get; set; }
    }
}
