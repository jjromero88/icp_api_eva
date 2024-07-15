using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using PCM.SIP.ICP.EVA.Transversal.Common;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Features
{
    public interface IEntidadOficialApplication
    {
        Task<PcmResponse> Insert(Request<EntidadOficialInsertRequestDto> request);
        Task<PcmResponse> Update(Request<EntidadOficialUpdateRequestDto> request);
        Task<PcmResponse> Delete(Request<EntidadOficialIdRequestDto> request);
        Task<PcmResponse> GetById(Request<EntidadOficialIdRequestDto> request);
        Task<PcmResponse> GetList(Request<EntidadOficialFilterRequestDto> request);
    }
}
