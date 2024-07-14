using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using PCM.SIP.ICP.EVA.Transversal.Common;
using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Features
{
    public interface IUbigeoApplication
    {
        Task<PcmResponse> GetListDepartamento();
        Task<PcmResponse> GetListProvincia(Request<ProvinciaFilterRequest> request);
        Task<PcmResponse> GetListDistrito(Request<DistritoFilterRequest> request);
    }
}
