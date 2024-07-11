using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Transversal.Contracts.Seguridad.Response
{
    public class SeguridadResponse
    {
        public int code { get; set; }
        public string? message { get; set; }
        public bool error { get; set; }
        public object? payload { get; set; }
    }
}
