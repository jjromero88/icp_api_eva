
namespace PCM.SIP.ICP.EVA.Domain.Entities
{
    public class Resultado : EntidadBase
    {
        public int resultado_id { get; set; }
        public int? preguntaetapa_id { get; set; }
        public int? entidadetapa_id { get; set; }
        public int? alternativa_id { get; set; }
        public string? preguntaetapakey { get; set; }
        public string? entidadetapakey { get; set; }
        public string? alternativakey { get; set; }
        public string? comentarios { get; set; }
        public string? etapa_nombre { get; set; }
        public string? etapa_descripcion { get; set; }
        public int? pregunta_numero { get; set; }
        public string? pregunta_descripcion { get; set; }
        public string? alternativa_opcion { get; set; }
        public string? alternativa_descripcion { get; set; }
        public bool? medioverificacion { get; set; }
        public List<MedioVerificacion>? lista_medioverificacion { get; set; }
    }
}
