using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure
{
    public interface IModalidadIntegridadService
    {
        Task<List<ModalidadIntegridadResponse>> GetList(ModalidadIntegridadFilterRequest request, string? token);
    }
}
