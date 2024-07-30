using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure
{
    public interface IEvaluacionService
    {
        Task<List<EvaluacionIcpResponse>> GetListEvaluacion(EvaluacionIcpFilterRequest request, string? token);
    }
}
