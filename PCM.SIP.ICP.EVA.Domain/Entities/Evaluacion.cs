using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Domain.Entities
{
    public class Evaluacion : EntidadBase
    {
        public int evaluacion_id { get; set; }
        public int? entidad_id { get; set; }
        public string? codigo { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }
        public string? descripcion { get; set; }
        public string? comentarios { get; set; }
        public bool? vigente { get; set; }
        public List<EvaluacionEtapa>? lista_etapas { get; set; }
    }
}
