using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure
{
    public interface IProfesionService
    {
        Task<List<ProfesionResponse>> GetList(ProfesionFilterRequest request, string? token);
    }
}
