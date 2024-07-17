using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Domain.Entities
{
    public class Document
    {
        public string? category { get; set; }
        public string? filename { get; set; }
        public string? extension { get; set; }
        public string? size { get; set; }
    }
}
