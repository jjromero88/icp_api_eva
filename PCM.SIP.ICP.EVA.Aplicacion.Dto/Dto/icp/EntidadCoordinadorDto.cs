
namespace PCM.SIP.ICP.EVA.Aplicacion.Dto
{
    public class EntidadCoordinadorIdRequestDto
    {
        public string? serialKey { get; set; }
    }
    public class EntidadCoordinadorInsertRequestDto
    {
        public string? entidadkey { get; set; }
        public string? modalidadkey { get; set; }
        public string? profesionkey { get; set; }
        public string? nombres { get; set; }
        public string? apellidos { get; set; }
        public string? numero_celular { get; set; }
        public string? correo_institucional { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }
        public bool? actual { get; set; }
        public DocumentInsertRequestDto? documento_designacion { get; set; }
    }
    public class EntidadCoordinadorUpdateRequestDto
    {
        public string? serialKey { get; set; }
        public string? entidadkey { get; set; }
        public string? modalidadkey { get; set; }
        public string? profesionkey { get; set; }
        public string? nombres { get; set; }
        public string? apellidos { get; set; }
        public string? numero_celular { get; set; }
        public string? correo_institucional { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }
        public bool? actual { get; set; }
        public DocumentInsertRequestDto? documento_designacion { get; set; }
    }
    public class EntidadCoordinadorFilterRequestDto
    {
        public string? serialKey { get; set; }
        public string? entidadkey { get; set; }
        public string? modalidadkey { get; set; }
        public string? profesionkey { get; set; }
        public string? filtro { get; set; }
        public bool? actual { get; set; }
    }
    public class EntidadCoordinadorResponseDto
    {
        public string? serialKey { get; set; }
        public string? entidadkey { get; set; }
        public string? modalidadkey { get; set; }
        public string? profesionkey { get; set; }
        public string? nombres { get; set; }
        public string? apellidos { get; set; }
        public string? numero_celular { get; set; }
        public string? correo_institucional { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }
        public bool? actual { get; set; }
        public DocumentResponseDto? documento_designacion { get; set; }
        public ProfesionResponseDto? profesion { get; set; }
        public ModalidadContratoResponseDto? modalidadcontrato { get; set; }
    }
}
