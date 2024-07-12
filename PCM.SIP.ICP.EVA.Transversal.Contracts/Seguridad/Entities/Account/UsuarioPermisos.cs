using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Transversal.Contracts.Seguridad.Account
{
    public class UsuarioPermisosrequest
    {
        public string? url { get; set; }
    }
    public class UsuarioPermisosResponse
    {
        public string[]? permisos { get; set; }
    }
}
