
using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure
{
    public interface IReportService
    {
        Task<(string FileName, string Base64Content)> GenerateReportAsync(string reportPath, string reportFormat,List<ProfesionResponse> profesiones);
    }
}
