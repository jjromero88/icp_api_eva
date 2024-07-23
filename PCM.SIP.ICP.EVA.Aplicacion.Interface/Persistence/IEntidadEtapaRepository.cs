using PCM.SIP.ICP.EVA.Domain.Entities;
using PCM.SIP.ICP.EVA.Transversal.Common;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Persistence
{
    public interface IEntidadEtapaRepository
    {
        Response GenerarFicha(EntidadEtapa entidad);
        Response AprobarFicha(EntidadEtapa entidad);
        Response Firmarficha(EntidadEtapa entidad);
    }
}
