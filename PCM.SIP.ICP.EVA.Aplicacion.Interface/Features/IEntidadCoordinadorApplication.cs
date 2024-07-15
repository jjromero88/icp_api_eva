using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using PCM.SIP.ICP.EVA.Transversal.Common;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Features
{
    public interface IEntidadCoordinadorApplication
    {
        Task<PcmResponse> Insert(Request<EntidadCoordinadorInsertRequestDto> request);
        Task<PcmResponse> Update(Request<EntidadCoordinadorUpdateRequestDto> request);
        Task<PcmResponse> Delete(Request<EntidadCoordinadorIdRequestDto> request);
        Task<PcmResponse> GetById(Request<EntidadCoordinadorIdRequestDto> request);
        Task<PcmResponse> GetList(Request<EntidadCoordinadorFilterRequestDto> request);
    }
}
