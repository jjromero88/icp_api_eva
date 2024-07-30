using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Aplicacion.Dto
{
    public class EvaluacionDto : EntidadBase
    {
        public int evaluacion_id { get; set; }
        public int entidad_id { get; set; }
        public string? codigo { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }
        public string? descripcion { get; set; }
        public string? comentarios { get; set; }
        public bool? vigente { get; set; }
        public List<EvaluacionEtapaDto>? lista_etapas { get; set; }
    }

    public class EvaluacionFilterRequest
    {
        public string? serialKey { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }
        public string? filtro { get; set; }
    }
    public class EvaluacionResponse
    {
        public string? serialKey { get; set; }
        public string? codigo { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }
        public string? descripcion { get; set; }
        public string? comentarios { get; set; }
        public bool? vigente { get; set; }
        public List<EvaluacionEtapaResponse>? lista_etapas { get; set; }
    }
    public class EvaluacionIcpResponseDto
    {
        public string? serialKey { get; set; }
        public string? codigo { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }
        public string? descripcion { get; set; }
        public string? comentarios { get; set; }
    }
}
