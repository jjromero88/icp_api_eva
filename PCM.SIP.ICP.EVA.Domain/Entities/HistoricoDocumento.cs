using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Domain.Entities
{
    public class HistoricoDocumento : EntidadBase
    {
        public int historicodocumento_id { get; set; }
        public int? fichahistorico_id { get; set; }
        public string? fichahistoricokey { get; set; }
        public string? historico_doc { get; set; }
    }
}
