using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;
using PCM.SIP.ICP.EVA.Transversal.Contracts.icp.Generics;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure
{
    public interface IEntidadService
    {
        Task<List<EntidadResponse>> GetListEntidad(EntidadFilterRequest request, string? token);
        Task<object?> UpdateGeneralidades(GeneralidadesUpdateRequest request, string? token);
        Task<GeneralidadesResponse> GetByIdGeneralidades(EntidadIdRequest request, string? token);
        Task<List<GeneralidadesResponse>> GetListGeneralidades(GeneralidadesFilterRequest request, string? token);
    }
}
