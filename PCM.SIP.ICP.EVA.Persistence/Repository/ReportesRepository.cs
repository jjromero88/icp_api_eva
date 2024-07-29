using Dapper;
using System.Data;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Persistence;
using PCM.SIP.ICP.EVA.Domain.Entities;
using PCM.SIP.ICP.EVA.Persistence.Context;
using PCM.SIP.ICP.EVA.Transversal.Common;

namespace PCM.SIP.ICP.EVA.Persistence.Repository
{
    public class ReportesRepository : IReportesRepository
    {
        private readonly DapperContext _context;

        public ReportesRepository(DapperContext context)
        {
            _context = context;
        }

        public Response<dynamic> ReporteAgrupadoPorEtapas(TotalEntidadesRequest entidad, out string jsonTotalEntidadesResponse)
        {
            Response<dynamic> retorno = new Response<dynamic>();
            jsonTotalEntidadesResponse = string.Empty;

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_SEL_REPORTE_TOTALENTIDADES";

                    var param = new DynamicParameters();

                    param.Add("evaluacion_id", entidad.evaluacion_id);
                    param.Add("etapa_id", entidad.etapa_id);
                    param.Add("entidad_id", entidad.entidad_id);
                    param.Add("error", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    param.Add("message", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                    param.Add("jsonTotalEntidades", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);

                    var result = connection.QuerySingleOrDefault<dynamic>(query, param: param, commandType: CommandType.StoredProcedure);

                    retorno.Data = string.Empty;
                    retorno.Error = param.Get<bool?>("error") ?? false;
                    retorno.Message = param.Get<string>("message") ?? string.Empty;
                    jsonTotalEntidadesResponse = param.Get<string>("jsonTotalEntidades") ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                retorno.Error = true;
                retorno.Message = ex.Message;
            }

            return retorno;
        }

        public Response<dynamic> ReporteAgrupadoPorGrupoEntidad(GrupoEntidadesRequest entidad, out string jsonGrupoEntidadesResponse)
        {
            Response<dynamic> retorno = new Response<dynamic>();
            jsonGrupoEntidadesResponse = string.Empty;

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_SEL_REPORTE_GRUPOENTIDADES";

                    var param = new DynamicParameters();

                    param.Add("evaluacion_id", entidad.evaluacion_id);
                    param.Add("etapa_id", entidad.etapa_id);
                    param.Add("entidadgrupo_id", entidad.entidadgrupo_id);
                    param.Add("error", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    param.Add("message", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                    param.Add("jsonGrupoEntidades", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);

                    var result = connection.QuerySingleOrDefault<dynamic>(query, param: param, commandType: CommandType.StoredProcedure);

                    retorno.Data = string.Empty;
                    retorno.Error = param.Get<bool?>("error") ?? false;
                    retorno.Message = param.Get<string>("message") ?? string.Empty;
                    jsonGrupoEntidadesResponse = param.Get<string>("jsonGrupoEntidades") ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                retorno.Error = true;
                retorno.Message = ex.Message;
            }

            return retorno;
        }

        public Response<dynamic> ReporteAgrupadoPorEtapaComponente(GrupoEtapasComponentesRequest entidad, out string jsonGrupoEtapaComponente)
        {
            Response<dynamic> retorno = new Response<dynamic>();
            jsonGrupoEtapaComponente = string.Empty;

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_SEL_REPORTE_PORENTIDAD";

                    var param = new DynamicParameters();

                    param.Add("evaluacion_id", entidad.evaluacion_id);
                    param.Add("etapa_id", entidad.etapa_id);
                    param.Add("componente_id", entidad.componente_id);
                    param.Add("entidad_id", entidad.entidad_id);
                    param.Add("error", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    param.Add("message", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                    param.Add("jsonPorEntidad", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);

                    var result = connection.QuerySingleOrDefault<dynamic>(query, param: param, commandType: CommandType.StoredProcedure);

                    retorno.Data = string.Empty;
                    retorno.Error = param.Get<bool?>("error") ?? false;
                    retorno.Message = param.Get<string>("message") ?? string.Empty;
                    jsonGrupoEtapaComponente = param.Get<string>("jsonPorEntidad") ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                retorno.Error = true;
                retorno.Message = ex.Message;
            }

            return retorno;
        }

    }
}
