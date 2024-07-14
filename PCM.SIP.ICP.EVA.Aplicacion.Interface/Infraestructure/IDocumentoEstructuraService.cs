using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure
{
    public interface IDocumentoEstructuraService
    {
        Task<List<DocumentoEstructuraResponse>> GetList(DocumentoEstructuraFilterRequest request, string? token);
    }
}
