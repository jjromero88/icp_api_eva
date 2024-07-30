using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Aplicacion.Dto
{
    public class EntidadIdRequestDto
    {
        public string? serialKey { get; set; }
    }
    public class EntidadResponseDto
    {
        public string? serialKey { get; set; }
        public string? entidadgrupokey { get; set; }
        public string? entidadsectorkey { get; set; }
        public string? numero_ruc { get; set; }
        public string? codigo { get; set; }
        public string? acronimo { get; set; }
        public string? nombre { get; set; }
    }
    public class GeneralidadesUpdateRequestDto
    {
        public string? serialKey { get; set; }
        public string? ubigeokey { get; set; }
        public string? documentoestructurakey { get; set; }
        public string? modalidadintegridadkey { get; set; }
        public string? modalidadintegridad_anterior { get; set; }
        public string? documentointegridad_desc { get; set; }
        public int? num_servidores { get; set; }
        public DocumentInsertRequestDto? documento_estructura { get; set; }
        public DocumentInsertRequestDto? documento_modalidadintegridad { get; set; }
        public DocumentInsertRequestDto? documento_integridad { get; set; }
    }
    public class GeneralidadesFilterRequestDto
    {
        public string? serialKey { get; set; }
        public string? entidadgrupokey { get; set; }
        public string? entidadsectorkey { get; set; }
        public string? ubigeokey { get; set; }
        public string? documentoestructurakey { get; set; }
        public string? modalidadintegridadkey { get; set; }
        public bool? generalidades { get; set; }
        public string? filtro { get; set; }
    }
    public class GeneralidadesResponseDto
    {
        public string? serialKey { get; set; }
        public string? entidadgrupokey { get; set; }
        public string? entidadsectorkey { get; set; }
        public string? ubigeokey { get; set; }
        public string? documentoestructurakey { get; set; }
        public string? modalidadintegridadkey { get; set; }
        public string? numero_ruc { get; set; }
        public string? codigo { get; set; }
        public string? acronimo { get; set; }
        public string? nombre { get; set; }
        public bool? generalidades { get; set; }
        public string? modalidadintegridad_anterior { get; set; }
        public string? documentointegridad_desc { get; set; }
        public int? num_servidores { get; set; }
        public DocumentResponseDto? documento_estructura { get; set; }
        public DocumentResponseDto? documento_modalidadintegridad { get; set; }
        public DocumentResponseDto? documento_integridad { get; set; }
        public UbigeoEntidadResponseDto? ubigeo { get; set; }
        public ModalidadIntegridadEntidadResponseDto? modalidadintegridad { get; set; }
        public DocumentoEstructuraEntidadResponseDto? documentoestructura { get; set; }
        public EntidadSectorEntidadResponseDto? entidadsector { get; set; }
        public EntidadGrupoEntidadResponseDto? entidadgrupo { get; set; }
    }
}
