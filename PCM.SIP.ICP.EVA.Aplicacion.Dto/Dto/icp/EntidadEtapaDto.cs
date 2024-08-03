using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Aplicacion.Dto
{
    public class EntidadEtapaDto : EntidadBase
    {
        public string? evaluacionetapakey { get; set; }
        public string? entidadkey { get; set; }
        public FichaEstadosDto? fichaestado { get; set; }
        public FichaHistoricoDto? fichahistorico { get; set; }
    }
    public class EntidadEtapaResponse
    {
        public string? serialKey { get; set; }
        public string? evaluacionetapakey { get; set; }
        public string? entidadkey { get; set; }
        public FichaEstadosResponse? fichaestado { get; set; }
    }
    public class AprobarFichaRequest
    {
        public string? serialKey { get; set; }
        public AprobarFichaHistoricoRequest? fichahistorico { get; set; }
    }
    public class FirmarFichaRequest
    {
        public string? serialKey { get; set; }
        public FirmarFichaHistoricoRequest? fichahistorico { get; set; }
    }
}
