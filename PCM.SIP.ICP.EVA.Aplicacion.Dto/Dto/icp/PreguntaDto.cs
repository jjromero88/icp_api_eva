
namespace PCM.SIP.ICP.EVA.Aplicacion.Dto
{
    public class PreguntaDto : EntidadBase
    {
        public string? componentekey { get; set; }
        public string? etapakey { get; set; }
        public string? codigo { get; set; }
        public int? numero { get; set; }
        public string? descripcion { get; set; }
        public bool? calculo_icp { get; set; }
        public bool? habilitado { get; set; }
        public EtapaDto? etapa { get; set; }
        public ComponenteDto? componente { get; set; }
        public List<AlternativaDto>? lista_alternativas { get; set; }
    }
    

    public class PreguntaResponse
    {
        public string? serialKey { get; set; }
        public string? componentekey { get; set; }
        public string? etapakey { get; set; }
        public string? codigo { get; set; }
        public int? numero { get; set; }
        public string? descripcion { get; set; }
        public bool? calculo_icp { get; set; }
        public bool? habilitado { get; set; }
        public EtapaResponse? etapa { get; set; }
        public ComponenteResponse? componente { get; set; }
        public List<AlternativaResponse>? lista_alternativas { get; set; }
    }
}
