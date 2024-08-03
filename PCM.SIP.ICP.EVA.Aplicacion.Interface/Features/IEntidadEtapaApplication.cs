using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using PCM.SIP.ICP.EVA.Transversal.Common;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Features
{
    public interface IEntidadEtapaApplication
    {
        Task<PcmResponse> AprobarFicha(Request<EntidadEtapaDto> request);
        Task<PcmResponse> FirmarFicha(Request<EntidadEtapaDto> request);
    }
}
