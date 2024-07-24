using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Aplicacion.Dto
{
    public class ReportDto
    {
        public string? format { get; set; }
    }

    public class ReportRequest
    {
        public string? format { get; set; }
    }
    public class ReportBase64Response
    {
        public string? filename { get; set; }
        public string? extension { get; set; }
        public string? base64content { get; set; }
    }
}
