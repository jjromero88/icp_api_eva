using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Transversal.Contracts.icp
{
    public class ComponenteIcpFilterRequest
    {
        public string? serialKey { get; set; }
        public string? filtro { get; set; }
    }
    public class ComponenteIcpResponse
    {
        public string? serialKey { get; set; }
        public string? codigo { get; set; }
        public string? descripcion { get; set; }
        public string? abreviatura { get; set; }
    }
}
