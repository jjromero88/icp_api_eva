using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Aplicacion.Dto
{
    public class EntidadGrupoEntidadResponseDto
    {
        public string? codigo { get; set; }
        public string? abreviatura { get; set; }
        public string? descripcion { get; set; }
    }
    public class EntidadGrupoFilterRequestDto
    {
        public string? serialKey { get; set; }
        public string? filtro { get; set; }
    }
    public class EntidadGrupoResponseDto
    {
        public string? serialKey { get; set; }
        public string? codigo { get; set; }
        public string? abreviatura { get; set; }
        public string? descripcion { get; set; }
    }
}
