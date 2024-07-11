
namespace PCM.SIP.ICP.EVA.Transversal.Common.Generics
{
    public class PcmResponse
    {
        public int Code { get; set; }
        public string? Message { get; set; }
        public bool error { get; set; }
        public object? Payload { get; set; }
    }
}
