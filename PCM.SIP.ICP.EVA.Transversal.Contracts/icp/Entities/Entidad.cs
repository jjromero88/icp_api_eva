using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Transversal.Contracts.icp
{
    public class EntidadIdRequest
    {
        public string? serialKey { get; set; }
    }
    public class GeneralidadesUpdateRequest
    {
        public string? serialKey { get; set; }
        public string? ubigeokey { get; set; }
        public string? documentoestructurakey { get; set; }
        public string? modalidadintegridadkey { get; set; }
        public string? modalidadintegridad_anterior { get; set; }
        public string? documentointegridad_desc { get; set; }
        public int? num_servidores { get; set; }
        public DocumentInsertRequest? documento_estructura { get; set; }
        public DocumentInsertRequest? documento_modalidadintegridad { get; set; }
        public DocumentInsertRequest? documento_integridad { get; set; }
    }
    public class GeneralidadesFilterRequest
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
    public class GeneralidadesResponse
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
        public DocumentResponse? documento_estructura { get; set; }
        public DocumentResponse? documento_modalidadintegridad { get; set; }
        public DocumentResponse? documento_integridad { get; set; }
        public UbigeoEntidadResponse? ubigeo { get; set; }
        public ModalidadIntegridadEntidadResponse? modalidadintegridad { get; set; }
        public DocumentoEstructuraEntidadResponse? documentoestructura { get; set; }
        public EntidadSectorEntidadResponse? entidadsector { get; set; }
        public EntidadGrupoEntidadResponse? entidadgrupo { get; set; }
    }
}
