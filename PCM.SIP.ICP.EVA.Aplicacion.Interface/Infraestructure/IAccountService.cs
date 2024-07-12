using PCM.SIP.ICP.EVA.Transversal.Contracts.Seguridad.Account;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure
{
    public interface IAccountService
    {
        Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest request);
        Task<AuthorizeResponse> AuthorizeAsync(AuthorizeRequest request);
        Task<List<UsuarioAccesosResponse>> UsuarioAccesosAsync(string? token);

    }
}
