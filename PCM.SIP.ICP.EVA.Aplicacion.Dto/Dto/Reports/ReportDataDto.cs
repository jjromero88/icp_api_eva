using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Aplicacion.Dto
{
    public class ReportDataDto
    {
        public string? evaluacionkey { get; set; }
        public string? etapakey { get; set; }
        public string? entidadkey { get; set; }
    }
    public class ReporteAgrupadoPorEtapasRequest
    {
        public string? evaluacionkey { get; set; }
        public string? etapakey { get; set; }
        public string? entidadkey { get; set; }
    }
    public class ReporteAgrupadoPorEtapasResponse
    {
        public string? etapa { get; set; } = string.Empty;
        public decimal? avance { get; set; } = decimal.Zero;
        public decimal? brecha { get; set; } = decimal.Zero;
    }
}
