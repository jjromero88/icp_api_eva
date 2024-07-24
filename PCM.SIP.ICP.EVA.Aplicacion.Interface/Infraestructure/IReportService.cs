
namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure
{
    public interface IReportService
    {
        Task<byte[]> GenerateReportAsync(string reportName, string reportPath);
    }
}
