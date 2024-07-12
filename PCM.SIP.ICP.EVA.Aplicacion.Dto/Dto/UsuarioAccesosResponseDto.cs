using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Aplicacion.Dto
{
    public class UsuarioAccesosResponseDto
    {
        public string? codigo { get; set; }
        public string? descripcion { get; set; }
        public string? abreviatura { get; set; }
        public string? url_opcion { get; set; }
        public string? icono_opcion { get; set; }
        public string? num_orden { get; set; }
        public List<UsuarioAccesosResponseDto>? listaAccesos { get; set; }
    }
}
