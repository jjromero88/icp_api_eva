using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Transversal.Contracts.icp
{
    public class EvaluacionIcpFilterRequest
    {
        public string? serialKey { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }
        public string? filtro { get; set; }
    }
    public class EvaluacionIcpResponse
    {
        public string? serialKey { get; set; }
        public string? codigo { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }
        public string? descripcion { get; set; }
        public string? comentarios { get; set; }
    }
}
