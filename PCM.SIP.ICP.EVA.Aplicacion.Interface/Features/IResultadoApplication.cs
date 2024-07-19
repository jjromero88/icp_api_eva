using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using PCM.SIP.ICP.EVA.Transversal.Common;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Features
{
    public interface IResultadoApplication
    {
        Task<PcmResponse> Insert(Request<List<ResultadoDto>> request);
        Task<PcmResponse> Update(Request<List<ResultadoDto>> request);
        Task<PcmResponse> GetList(Request<ResultadoDto> request);
    }
}
