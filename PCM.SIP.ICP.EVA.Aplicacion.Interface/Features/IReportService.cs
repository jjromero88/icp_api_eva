using System.Data;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Features
{
    public interface IReportService
    {
        Task<byte[]> GenerateReportAsync(string reportName);
    }
}
