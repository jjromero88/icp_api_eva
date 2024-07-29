using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Aplicacion.Dto
{
    public class ReportDto
    {
        public string? evaluacionkey { get; set; }
        public string? etapakey { get; set; }
        public string? entidadkey { get; set; }
        public string? grupokey { get; set; }
        public string? componentekey { get; set; }
        public string? filename { get; set; }
        public string? extension { get; set; }
        public string? base64content { get; set; }
    }

    /* Reporte: Agrupado por etapas */

    public class ReportResultadosEtapaRequest
    {
        public string? evaluacionkey { get; set; }
        public string? etapakey { get; set; }
        public string? entidadkey { get; set; }
        public string? format { get; set; }
        public string? interpretacion { get; set; }
        public List<ResultadosEtapa>? data { get; set; }
    }
    public class ResultadosEtapa
    {
        public string? etapa { get; set; }
        public decimal? avance { get; set; }
        public decimal? brecha { get; set; }
    }
    public class ResultadosEtapaGroup
    {
        public string? Etapa { get; set; }
        public string? Tipo { get; set; }
        public decimal? Valor { get; set; }
    }

    /* Reporte: Agrupado por Grupo de Entidad */

    public class ReportGrupoEntidadesRequest
    {
        public string? format { get; set; }
        public string? titulo { get; set; }
        public string? interpretacion { get; set; }
        public List<GrupoEntidades>? data { get; set; }
    }
    public class GrupoEntidades
    {
        public string? grupo { get; set; }
        public string? etapa_nombre { get; set; }
        public decimal? avance { get; set; }
    }

    /* Reporte: Agrupado por Etapa y Componente */

    public class ReportEtapasComponenteRequest
    {
        public string? format { get; set; }
        public string? interpretacion { get; set; }
        public List<EtapasComponente>? data { get; set; }
    }

    public class EtapasComponente
    {
        public string? etapa_nombre { get; set; }
        public string? etapa_descripcion { get; set; }
        public string? componente_nombre { get; set; }
        public decimal? resultado { get; set; }
    }


    /* Reporte response */

    public class ReportBase64Response
    {
        public string? filename { get; set; }
        public string? extension { get; set; }
        public string? base64content { get; set; }
    }
}
