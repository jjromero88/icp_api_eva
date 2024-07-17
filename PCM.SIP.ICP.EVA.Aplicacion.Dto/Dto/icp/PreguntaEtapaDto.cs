using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Aplicacion.Dto
{
    public class PreguntaEtapaDto : EntidadBase
    {
        public string? evaluacionetapakey { get; set; }
        public string? preguntakey { get; set; }
        public PreguntaDto? pregunta { get; set; }
    }

    public class PreguntaEtapaFilterRequest
    {
        public string? evaluacionetapakey { get; set; }
    }

    public class PreguntaEtapaResponse
    {
        public string? serialKey { get; set; }
        public string? evaluacionetapakey { get; set; }
        public string? preguntakey { get; set; }
        public PreguntaResponse? pregunta { get; set; }
    }
}
