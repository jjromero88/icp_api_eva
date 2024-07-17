using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Aplicacion.Dto
{
    public class EntidadEtapaDto : EntidadBase
    {
        public string? evaluacionetapakey { get; set; }
        public string? entidadkey { get; set; }
    }
    public class EntidadEtapaResponse
    {
        public string? serialKey { get; set; }
        public string? evaluacionetapakey { get; set; }
        public string? entidadkey { get; set; }
    }
}
