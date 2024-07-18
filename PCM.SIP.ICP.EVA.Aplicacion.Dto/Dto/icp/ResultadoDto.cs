using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Aplicacion.Dto
{
    public class ResultadoDto: EntidadBase
    {      
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
        public List<MedioVerificacionDto>? lista_medioverificacion { get; set; }
    }
    public class ResultadoFilterRequest
    {
        public string? serialKey { get; set; }
        public string? preguntaetapakey { get; set; }
        public string? entidadetapakey { get; set; }
        public string? alternativakey { get; set; }
    }
    public class ResultadoResponse
    {
        public string? serialKey { get; set; }
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
        public List<MedioVerificacionResponse>? lista_medioverificacion { get; set; }
    }
}
