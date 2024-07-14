using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using PCM.SIP.ICP.EVA.Transversal.Common;
using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Features
{
    public interface IModalidadIntegridadApplication
    {
        Task<PcmResponse> GetList(Request<ModalidadIntegridadFilterRequest> request);
    }
}
