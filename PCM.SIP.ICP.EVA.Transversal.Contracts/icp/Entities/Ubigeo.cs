using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Transversal.Contracts.icp
{
    public class Ubigeo
    {
        public string? serialKey { get; set; }
        public string? departamento_inei { get; set; }
        public string? provincia_inei { get; set; }
        public string? departamento { get; set; }
        public string? provincia { get; set; }
        public string? distrito { get; set; }
    }
    public class UbigeoEntidadResponse
    {
        public string? departamento_inei { get; set; }
        public string? provincia_inei { get; set; }
        public string? departamento { get; set; }
        public string? provincia { get; set; }
        public string? distrito { get; set; }
    }
    public class ProvinciaFilterRequest
    {
        public string? departamento_inei { get; set; }
    }
    public class DistritoFilterRequest
    {
        public string? provincia_inei { get; set; }
    }
    public class DepartamentoResponse
    {
        public string? departamento_inei { get; set; }
        public string? departamento { get; set; }
    }
    public class ProvinciaResponse
    {
        public string? departamento_inei { get; set; }
        public string? provincia_inei { get; set; }
        public string? provincia { get; set; }
    }
    public class DistritoResponse
    {
        public string? serialKey { get; set; }
        public string? distrito { get; set; }
    }
}
