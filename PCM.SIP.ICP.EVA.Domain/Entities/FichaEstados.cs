
namespace PCM.SIP.ICP.EVA.Domain.Entities
{
    public class FichaEstados : EntidadBase
    {
        public int fichaestado_id { get; set; }
        public string? codigo { get; set; }
        public string? nombre { get; set; }
        public string? descripcion { get; set; }
    }
}
