using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Aplicacion.Dto
{
    public class ReportTotalEntidadesrequest
    {
        public string? format { get; set; }
        public List<TotalEntidadesrequest>? data { get; set; }
    }

    public class TotalEntidadesrequest
    {
        public string? etapa { get; set; }
        public decimal? avance { get; set; }
        public decimal? brecha { get; set; }
        public string? graficobase64 { get; set; }
    }

    public class ReportBase64Response
    {
        public string? filename { get; set; }
        public string? extension { get; set; }
        public string? base64content { get; set; }
    }
}
