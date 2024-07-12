using PCM.SIP.ICP.EVA.Transversal.Contracts.Seguridad;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure
{
    public interface IUserSessionService
    {
        void SetToken(string token);
        void SetUser(string entidad);
        UsuarioCache GetUser();
        string GetToken();
    }
}
