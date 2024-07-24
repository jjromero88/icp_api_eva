using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Features
{
    public interface IReportDocumentService
    {
        Task<byte[]> GenerateReportAsync(string reportName);
    }
}
