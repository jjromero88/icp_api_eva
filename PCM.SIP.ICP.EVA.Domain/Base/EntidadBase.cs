using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Domain
{
    public class EntidadBase
    {
        public string? SerialKey { get; set; }
        public bool? estado { get; set; }
        public string? usuario_reg { get; set; }
        public DateTime? fecha_reg { get; set; }
        public string? usuario_act { get; set; }
        public DateTime? fecha_act { get; set; }
        public string? filtro { get; set; }
    }
}
