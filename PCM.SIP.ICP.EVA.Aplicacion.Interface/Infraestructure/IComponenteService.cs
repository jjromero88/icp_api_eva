using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure
{
    public interface IComponenteService
    {
        Task<List<ComponenteIcpResponse>> GetList(ComponenteIcpFilterRequest request, string? token);
    }
}
