using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using PCM.SIP.ICP.EVA.Transversal.Common;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Features
{
    public interface IMedioVerificacionApplication
    {
        Task<PcmResponse> UploadDocument(MedioVerificacionDocumentUploadRequest request);
    }
}
