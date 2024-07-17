using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Domain.Entities
{
    public class EvaluacionEtapa : EntidadBase
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
        public Evaluacion? evaluacion { get; set; }
        public Etapa? etapa { get; set; }
        public EntidadEtapa? entidadetapa { get; set; }
    }
}
