using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure
{
    public interface IUbigeoService
    {
        Task<List<DepartamentoResponse>> GetListDepartamentos(string? token);
        Task<List<ProvinciaResponse>> GetListProvincias(ProvinciaFilterRequest request, string? token);
        Task<List<DistritoResponse>> GetListDistritos(DistritoFilterRequest request, string? token);
    }
}
