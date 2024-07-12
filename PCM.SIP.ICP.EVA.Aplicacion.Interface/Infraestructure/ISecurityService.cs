using PCM.SIP.ICP.EVA.Transversal.Contracts.Seguridad;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure
{
    public interface ISecurityService
    {
        Task<UsuarioCache> GetSessionDataAsync(string token);
        Task<bool> ValidateToken(string token);
    }
}
