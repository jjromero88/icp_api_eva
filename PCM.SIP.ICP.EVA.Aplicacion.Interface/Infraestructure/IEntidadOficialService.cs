using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using PCM.SIP.ICP.EVA.Transversal.Common;
using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure
{
    public interface IEntidadOficialService
    {
        Task<object?> Insert(EntidadOficialInsertRequest request, string? token);
        Task<object?> Update(EntidadOficialUpdateRequest request, string? token);
        Task<object?> Delete(EntidadOficialIdRequest request, string? token);
        Task<EntidadOficialResponse> GetById(EntidadOficialIdRequest request, string? token);
        Task<List<EntidadOficialResponse>> GetList(EntidadOficialFilterRequest request, string? token);
    }
}
