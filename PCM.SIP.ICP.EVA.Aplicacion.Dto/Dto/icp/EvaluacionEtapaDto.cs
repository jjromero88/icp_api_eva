using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Aplicacion.Dto
{
    public class EvaluacionEtapaDto : EntidadBase
    {
        public int evaluacionetapa_id { get; set; }
        public int? evaluacion_id { get; set; }
        public int? etapa_id { get; set; }
        public string? evaluacionkey { get; set; }
        public string? etapakey { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }
        public string? comentarios { get; set; }
        public bool? habilitado { get; set; }
        public bool? vigente { get; set; }
        public EtapaDto? etapa { get; set; }
        public EvaluacionDto? evaluacion { get; set; }
        public EntidadEtapaDto? entidadetapa { get; set; }
    }

    public class EvaluacionEtapaResponse
    {
        public string? serialKey { get; set; }
        public string? evaluacionkey { get; set; }
        public string? etapakey { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }
        public string? comentarios { get; set; }
        public bool? habilitado { get; set; }
        public bool? vigente { get; set; }
        public EvaluacionResponse? evaluacion { get; set; }
        public EtapaResponse? etapa { get; set; }
        public EntidadEtapaResponse? entidadetapa { get; set; }
    }
}
