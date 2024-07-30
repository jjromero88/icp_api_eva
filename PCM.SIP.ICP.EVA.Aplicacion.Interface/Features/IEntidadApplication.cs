using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Transversal.Common;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Features
{
    public interface IEntidadApplication
    {
        Task<PcmResponse> GetListEntidad();
        Task<PcmResponse> UpdateGeneralidades(Request<GeneralidadesUpdateRequestDto> request);
        Task<PcmResponse> GetByIdGeneralidades(Request<EntidadIdRequestDto> request);
        Task<PcmResponse> GetListGeneralidades(Request<GeneralidadesFilterRequestDto> request);
    }
}
