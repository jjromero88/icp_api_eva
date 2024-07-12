using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Aplicacion.Dto
{
    public class UsuarioPermisosrequestDto
    {
        public string? url { get; set; }
    }
    public class UsuarioPermisosResponseDto
    {
        public string[]? permisos { get; set; }
    }
}
