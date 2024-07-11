using System.Text.Json.Serialization;

namespace PCM.SIP.ICP.EVA.Infraestructure
{
    public class IcpSegResponse<T>
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("error")]
        public bool Error { get; set; }

        [JsonPropertyName("payload")]
        public T? Payload { get; set; }
    }
}
