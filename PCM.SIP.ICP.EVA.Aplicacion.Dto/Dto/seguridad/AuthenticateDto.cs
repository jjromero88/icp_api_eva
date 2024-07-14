using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Aplicacion.Dto
{
    public class AuthenticateRequestDto
    {
        public string? username { get; set; }
        public string? password { get; set; }
    }
    public class AuthenticateResponseDto
    {
        public string? idsession { get; set; }
        public string? username { get; set; }
        public string? nombre_completo { get; set; }
        public List<AuthenticatePerfilDto> lista_perfiles { get; set; } = new List<AuthenticatePerfilDto> { };
    }

    public class AuthenticatePerfilDto
    {
        public string? codigo { get; set; }
        public string? descripcion { get; set; }
    }
}
