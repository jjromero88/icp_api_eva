using PCM.SIP.ICP.EVA.Transversal.Contracts.Seguridad.Entities;
using System.Text.Json.Serialization;

namespace PCM.SIP.ICP.EVA.Transversal.Contracts.Seguridad.Response
{
    public class ResponseSecurityService
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("error")]
        public bool Error { get; set; }

        [JsonPropertyName("payload")]
        public UsuarioCache? Payload { get; set; }
    }
}
