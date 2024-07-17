using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using PCM.SIP.ICP.EVA.Transversal.Common;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Features
{
    public interface IPreguntaEtapaApplication
    {
        Task<PcmResponse> GetList(Request<PreguntaEtapaDto> request);
    }
}
