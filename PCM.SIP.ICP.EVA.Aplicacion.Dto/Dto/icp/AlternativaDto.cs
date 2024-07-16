using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Aplicacion.Dto
{
    public class AlternativaDto : EntidadBase
    {
        public string? preguntakey { get; set; }
        public string? codigo { get; set; }
        public string? alternativa { get; set; }
        public string? descripcion { get; set; }
        public decimal? valor { get; set; }
        public bool? medio_verificacion { get; set; }
        public int? numero_orden { get; set; }
    }
    public class AlternativaResponse
    {
        public string? codigo { get; set; }
        public string? alternativa { get; set; }
        public string? descripcion { get; set; }
        public decimal? valor { get; set; }
        public bool? medio_verificacion { get; set; }
        public int? numero_orden { get; set; }
    }
}
