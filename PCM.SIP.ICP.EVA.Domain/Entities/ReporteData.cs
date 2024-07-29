using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Domain.Entities
{
    public class TotalEntidadesRequest
    {
        public int? evaluacion_id { get; set; }
        public int? etapa_id { get; set; }
        public int? entidad_id { get; set; }
    }

    public class TotalEntidadesResponse
    {
        public string? etapa { get; set; } = string.Empty;
        public decimal? avance { get; set; } = decimal.Zero;
        public decimal? brecha { get; set; } = decimal.Zero;
    }

    public class GrupoEntidadesRequest
    {
        public int? evaluacion_id { get; set; }
        public int? etapa_id { get; set; }
        public int? entidadgrupo_id { get; set; }
    }
    public class GrupoEntidadesResponse
    {
        public string? grupo { get; set; }
        public string? etapa_abreviatura { get; set; }
        public string? etapa_nombre { get; set; }
        public decimal? avance { get; set; } = decimal.Zero;
        public decimal? brecha { get; set; } = decimal.Zero;
    }
    public class GrupoEtapasComponentesRequest
    {
        public int? evaluacion_id { get; set; }
        public int? etapa_id { get; set; }
        public int? componente_id { get; set; }
        public int? entidad_id { get; set; }
    }
    public class GrupoEtapasComponentesResponse
    {
        public string? etapa_abreviatura { get; set; }
        public string? etapa_nombre { get; set; }
        public string? etapa_descripcion { get; set; }
        public string? componente_nombre { get; set; }
        public decimal? resultado { get; set; } = decimal.Zero;
    }
}
