using PCM.SIP.ICP.EVA.Domain.Entities;
using PCM.SIP.ICP.EVA.Transversal.Common;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Persistence
{
    public interface IReportesRepository
    {
        Response<dynamic> ReporteAgrupadoPorEtapas(TotalEntidadesRequest entidad, out string jsonTotalEntidadesResponse);
    }
}
