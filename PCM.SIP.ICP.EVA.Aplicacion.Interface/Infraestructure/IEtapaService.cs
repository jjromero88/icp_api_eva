using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure
{
    public interface IEtapaService
    {
        Task<List<EtapaIcpResponse>> GetList(EtapaIcpFilterRequest request, string? token);
    }
}
