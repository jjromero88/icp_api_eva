using PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.EVA.Transversal.Contracts.Seguridad;
using System.Text.Json;

namespace PCM.SIP.ICP.EVA.Infraestructure.Services
{
    public class UserSessionService : IUserSessionService
    {
        private UsuarioCache _usuarioCache;
        private string _token;

        public string GetToken()
        {
            return _token;
        }

        public UsuarioCache GetUser()
        {
            return _usuarioCache;
        }

        public void SetToken(string token)
        {
            _token = token;
        }

        public void SetUser(string entidad)
        {
            try
            {
                var result = JsonSerializer.Deserialize<UsuarioCache>(entidad);

                if (result == null)
                    throw new Exception($"Error al deserializar el usuario de sesion");

                _usuarioCache = result;
            }
            catch
            (Exception ex)
            {
                throw new Exception($"Error al obtener datos del usuario: {ex.Message}", ex);
            }
        }
    }
}
