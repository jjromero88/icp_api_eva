using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Transversal.Contracts.icp
{
    public class EntidadOficialIdRequest
    {
        public string? serialKey { get; set; }
    }
    public class EntidadOficialInsertRequest
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
        public DocumentInsertRequest? documento_designacion { get; set; }
    }
    public class EntidadOficialUpdateRequest
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
        public DocumentInsertRequest? documento_designacion { get; set; }
    }
    public class EntidadOficialFilterRequest
    {
        public string? serialKey { get; set; }
        public string? entidadkey { get; set; }
        public string? modalidadkey { get; set; }
        public string? profesionkey { get; set; }
        public string? filtro { get; set; }
        public bool? actual { get; set; }
    }
    public class EntidadOficialResponse
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
        public DocumentResponse? documento_designacion { get; set; }
        public ProfesionResponse? profesion { get; set; }
        public ModalidadContratoResponse? modalidadcontrato { get; set; }
    }
}
