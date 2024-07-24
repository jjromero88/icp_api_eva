
using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure
{
    public interface IReportService
    {
        Task<byte[]> GenerateReportAsync(string reportName, string reportPath, List<ProfesionResponse> profesiones);
    }
}
