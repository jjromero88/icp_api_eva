using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure
{
    public interface IEntidadGrupoService
    {
        Task<List<EntidadGrupoResponse>> GetList(EntidadGrupoFilterRequest request, string? token);
    }
}
