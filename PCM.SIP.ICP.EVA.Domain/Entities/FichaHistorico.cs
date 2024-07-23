using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Domain.Entities
{
    public class FichaHistorico : EntidadBase
    {
        public int fichahistorico_id { get; set; }
        public int? entidadetapa_id { get; set; }
        public int? estadoanterior_id { get; set; }
        public int? estadonuevo_id { get; set; }
        public int? usuario_id { get; set; }
        public int? perfil_id { get; set; }
        public string? entidadetapakey { get; set; }
        public string? estadoanteriorkey { get; set; }
        public string? estadonuevokey { get; set; }
        public string? usuariokey { get; set; }
        public string? perfilkey { get; set; }
        public string? comentarios { get; set; }
        public string? descripcion { get; set; }
    }
}
