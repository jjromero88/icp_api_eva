using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Transversal.Contracts.Seguridad.Response
{
    public class PerfilUsuarioResponse
    {
        public string? serialKey { get; set; }
        public string? codigo { get; set; }
        public string? abreviatura { get; set; }
        public string? descripcion { get; set; }
    }
}
