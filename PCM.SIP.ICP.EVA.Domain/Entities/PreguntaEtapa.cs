
namespace PCM.SIP.ICP.EVA.Domain.Entities
{
    public class PreguntaEtapa : EntidadBase
    {
        public int preguntaetapa_id { get; set; }
        public int? evaluacionetapa_id { get; set; }
        public int? pregunta_id { get; set; }
        public string? evaluacionetapakey { get; set; }
        public string? preguntakey { get; set; }
        public Pregunta? pregunta { get; set; }
    }
}
