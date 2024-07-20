
namespace PCM.SIP.ICP.EVA.Domain.Entities
{
    public class MedioVerificacion : EntidadBase
    {
        public int? medioverificacion_id { get; set; }
        public int? resultado_id { get; set; }
        public string? resultadokey { get; set; }
        public string? verificacion_doc { get; set; }
        public Document? verificacion_documento { get; set; }
    }
}
