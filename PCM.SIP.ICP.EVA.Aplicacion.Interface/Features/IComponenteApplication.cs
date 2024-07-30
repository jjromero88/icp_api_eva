using PCM.SIP.ICP.EVA.Transversal.Common.Generics;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Features
{
    public interface IComponenteApplication
    {
        Task<PcmResponse> GetList();
    }
}
