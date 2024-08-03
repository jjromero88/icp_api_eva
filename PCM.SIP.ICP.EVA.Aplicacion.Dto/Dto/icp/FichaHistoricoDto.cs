using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Aplicacion.Dto
{
    public class FichaHistoricoDto: EntidadBase
    {
        public string? entidadetapakey { get; set; }
        public string? estadoanteriorkey { get; set; }
        public string? estadonuevokey { get; set; }
        public string? usuariokey { get; set; }
        public string? perfilkey { get; set; }
        public string? comentarios { get; set; }
        public string? descripcion { get; set; }
        public DocumentDto? ficha_documento { get; set; }
    }

    public class AprobarFichaHistoricoRequest
    {
        public string? comentarios { get; set; }
    }
    public class FirmarFichaHistoricoRequest
    {
        public string? comentarios { get; set; }
        public DocumentInsertRequestDto? ficha_documento { get; set; }
    }
}
