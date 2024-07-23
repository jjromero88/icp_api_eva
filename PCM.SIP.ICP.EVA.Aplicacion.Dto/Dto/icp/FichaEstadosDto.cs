using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Aplicacion.Dto
{
    public class FichaEstadosDto: EntidadBase
    {
        public string? codigo { get; set; }
        public string? nombre { get; set; }
        public string? descripcion { get; set; }
    }

    public class FichaEstadosResponse
    {
        public string? codigo { get; set; }
        public string? nombre { get; set; }
        public string? descripcion { get; set; }
    }
}
