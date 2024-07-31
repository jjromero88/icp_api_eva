using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Aplicacion.Dto
{
    public class EntidadSectorEntidadResponseDto
    {
        public string? codigo { get; set; }
        public string? abreviatura { get; set; }
        public string? descripcion { get; set; }
    }

    public class EntidadSectorResponseDto
    {
        public string? serialKey { get; set; }
        public string? tiposectorkey { get; set; }
        public string? codigo { get; set; }
        public string? abreviatura { get; set; }
        public string? descripcion { get; set; }
    }
}
