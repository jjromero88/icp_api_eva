using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Transversal.Common;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Features
{
    public interface IReportDocumentService
    {
        Task<PcmResponse> ReporteTotalEntidadesAsync(ReportTotalEntidadesrequest request);
    }
}
