using PCM.SIP.ICP.EVA.Domain.Entities;
using PCM.SIP.ICP.EVA.Transversal.Common;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Persistence
{
    public interface IReportesRepository
    {
        Response<dynamic> ReporteAgrupadoPorEtapas(TotalEntidadesRequest entidad, out string jsonTotalEntidadesResponse);
        Response<dynamic> ReporteAgrupadoPorGrupoEntidad(GrupoEntidadesRequest entidad, out string jsonGrupoEntidadesResponse);
        Response<dynamic> ReporteAgrupadoPorEtapaComponente(GrupoEtapasComponentesRequest entidad, out string jsonGrupoEtapaComponente);
        Response<dynamic> ReporteResultadoPorSector(ResultadoPorSectorRequest entidad, out string jsonResultadosTotales);
    }
}
