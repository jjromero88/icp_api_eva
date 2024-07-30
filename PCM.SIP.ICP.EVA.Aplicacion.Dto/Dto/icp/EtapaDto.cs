using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Aplicacion.Dto
{
    public class EtapaDto : EntidadBase
    {
        public int etapa_id { get; set; }
        public string? codigo { get; set; }
        public string? nombre { get; set; }
        public string? abreviatura { get; set; }
        public string? descripcion { get; set; }
    }
    public class EtapaResponse
    {
        public string? serialKey { get; set; }
        public string? codigo { get; set; }
        public string? nombre { get; set; }
        public string? abreviatura { get; set; }
        public string? descripcion { get; set; }
    }
    public class EtapaIcpResponseDto
    {
        public string? serialKey { get; set; }
        public string? codigo { get; set; }
        public string? nombre { get; set; }
        public string? abreviatura { get; set; }
        public string? descripcion { get; set; }
    }
}
