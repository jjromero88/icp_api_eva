using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Persistence
{
    public interface IDocumentRepository
    {
        Task<string> SaveDocumentAsync(string fileName, string base64Content, string category);
        Task<(string FileName, string Base64Content)> DownloadDocumentAsync(string categoryPath, string fileName);
    }
}
