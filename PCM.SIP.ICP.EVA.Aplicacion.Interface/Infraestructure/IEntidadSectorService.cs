using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure
{
    public interface IEntidadSectorService
    {
        Task<List<EntidadSectorResponse>> GetList(EntidadSectorFilterRequest request, string? token);
    }
}
