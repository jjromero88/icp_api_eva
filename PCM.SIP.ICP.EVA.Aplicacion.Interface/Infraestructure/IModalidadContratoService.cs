using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure
{
    public interface IModalidadContratoService
    {
        Task<List<ModalidadContratoResponse>> GetList(ModalidadContratoFilterRequest request, string? token);
    }
}
