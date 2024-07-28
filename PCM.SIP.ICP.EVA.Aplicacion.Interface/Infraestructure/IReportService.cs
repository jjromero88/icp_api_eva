using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure
{
    public interface IReportService
    {
        Task<(string FileName, string Base64Content)> ReporteTotalEntidadesAsync(string reportFormat, List<TotalEntidadesrequest> data);
        Task<byte[]> ReporteGrupoEntidadesAsync(ReportGrupoEntidadesRequest request);
        Task<byte[]> ReporteEtapaComponenteAsync(ReportEtapasComponenteRequest request);
    }
}
