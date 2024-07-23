using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Domain.Entities
{
    public class EntidadEtapa : EntidadBase
    {
        public int entidadetapa_id { get; set; }
        public int? evaluacionetapa_id { get; set; }
        public int? entidad_id { get; set; }
        public string? evaluacionetapakey { get; set; }
        public string? entidadkey { get; set; }
        public FichaHistorico? fichahistorico { get; set; }
    }
}
