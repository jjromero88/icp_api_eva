
namespace PCM.SIP.ICP.EVA.Transversal.Contracts.Seguridad.Account
{
    public class AuthenticateRequest
    {
        public string? username { get; set; }
        public string? password { get; set; }
    }

    public class AuthenticateResponse
    {
        public string? idsession { get; set; }
        public string? username { get; set; }
        public string? nombre_completo { get; set; }
        public List<AuthenticatePerfil> lista_perfiles { get; set; } = new List<AuthenticatePerfil> { };
    }

    public class AuthenticatePerfil
    {
        public string? codigo { get; set; }
        public string? descripcion { get; set; }
    }
}
