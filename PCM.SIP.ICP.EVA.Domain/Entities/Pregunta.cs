using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Domain.Entities
{
    public class Pregunta : EntidadBase
    {
        public int pregunta_id { get; set; }
        public int? componente_id { get; set; }
        public int? etapa_id { get; set; }
        public int? evaluacionetapa_id { get; set; }
        public int? entidad_id { get; set; }
        public string? componentekey { get; set; }
        public string? etapakey { get; set; }
        public string? evaluacionetapakey { get; set; }
        public string? codigo { get; set; }
        public int? numero { get; set; }
        public string? descripcion { get; set; }
        public bool? calculo_icp { get; set; }
        public bool? habilitado { get; set; }
        public Componente? componente { get; set; }
        public Etapa? etapa { get; set; }
        public List<Alternativa>? lista_alternativas { get; set; }
    }
}
