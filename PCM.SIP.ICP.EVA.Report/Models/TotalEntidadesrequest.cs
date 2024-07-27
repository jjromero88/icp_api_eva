using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Report
{
    public class TotalEntidadesrequest
    {
        public string etapa { get; set; }
        public decimal avance { get; set; }
        public decimal brecha { get; set; }
        public string graficobase64 { get; set; }
    }
}
