using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Features
{
    public interface IDocumentService
    {
        Task<PcmResponse> UploadDocumentAsync(UploadDocumentRequestDto request);
        Task<PcmResponse> DownloadDocumentAsync(DownloadDocumentRequestDto request);
    }
}
