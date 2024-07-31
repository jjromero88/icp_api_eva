using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Domain.Entities;
using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure
{
    public interface IReportService
    {
        Task<byte[]> ReporteGrupoEntidadesAsync(ReportGrupoEntidadesRequest request);
        Task<byte[]> ReporteEtapaComponenteAsync(ReportEtapasComponenteRequest request);
        Task<byte[]> ReporteResultadoEtapaAsync(ReportResultadosEtapaRequest request);
        Task<byte[]> ReporteResultadoPorSectorAsync(ResultadoPorSectorResponse request);
    }
}
