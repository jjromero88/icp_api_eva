using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Domain.Entities
{
    public class TypeResultado
    {
        public int resultado_id { get; set; }
        public int? preguntaetapa_id { get; set; }
        public int? entidadetapa_id { get; set; }
        public int? alternativa_id { get; set; }
        public string? comentarios { get; set; }
        public string? etapa_nombre { get; set; }
        public string? etapa_descripcion { get; set; }
        public int? pregunta_numero { get; set; }
        public string? pregunta_descripcion { get; set; }
        public string? alternativa_opcion { get; set; }
        public string? alternativa_descripcion { get; set; }
        public bool? medioverificacion { get; set; }
    }
}
