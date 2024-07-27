using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Domain.Entities
{
    public class ReporteParametros
    {
        public int? evaluacion_id { get; set; }
        public int? etapa_id { get; set; }
        public int? entidad_id { get; set; }
    }

    public class ReporteTotalEntidades
    {
        public string? etapa { get; set; }
        public decimal? avance { get; set; }
        public decimal? brecha { get; set; }
    }
}
