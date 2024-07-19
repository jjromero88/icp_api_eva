using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Domain.Entities
{
    public class TypeMedioVerificacion
    {
        public int medioverificacion_id { get; set; }
        public int? resultado_id { get; set; }
        public string? verificacion_doc { get; set; }
    }
}
