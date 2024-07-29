using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using PCM.SIP.ICP.EVA.Transversal.Common;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Features
{
    public interface IReportDataApplication
    {
        Task<PcmResponse> ReporteAgrupadoPorEtapas(Request<ReportDataDto> request);
        Task<PcmResponse> ReporteAgrupadoPorGrupoEntidad(Request<ReportDataDto> request);
        Task<PcmResponse> ReporteAgrupadoPorEtapaComponente(Request<ReportDataDto> request);
    }
}
