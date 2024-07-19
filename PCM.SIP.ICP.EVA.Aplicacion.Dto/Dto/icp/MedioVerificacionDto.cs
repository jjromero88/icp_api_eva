
namespace PCM.SIP.ICP.EVA.Aplicacion.Dto
{
    public class MedioVerificacionDto
    {
        public string? serialKey { get; set; }
        public string? resultadokey { get; set; }
        public string? verificacion_doc { get; set; }
        public DocumentDto? verificacion_documento { get; set; }
    }

    public class MedioVerificacionInsertRequest
    {
        public string? resultadokey { get; set; }
        public DocumentInsertRequestDto? verificacion_documento { get; set; }
    }

    public class MedioVerificacionResponse
    {
        public string? serialKey { get; set; }
        public string? resultadokey { get; set; }
        public DocumentResponseDto? verificacion_documento { get; set; }
    }
}
