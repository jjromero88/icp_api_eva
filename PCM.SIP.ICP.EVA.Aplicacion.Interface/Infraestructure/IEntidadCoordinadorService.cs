using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using PCM.SIP.ICP.EVA.Transversal.Common;
using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure
{
    public interface IEntidadCoordinadorService
    {
        Task<object?> Insert(EntidadCoordinadorInsertRequest request, string? token);
        Task<object?> Update(EntidadCoordinadorUpdateRequest request, string? token);
        Task<object?> Delete(EntidadCoordinadorIdRequest request, string? token);
        Task<EntidadCoordinadorResponse> GetById(EntidadCoordinadorIdRequest request, string? token);
        Task<List<EntidadCoordinadorResponse>> GetList(EntidadCoordinadorFilterRequest request, string? token);
    }
}
