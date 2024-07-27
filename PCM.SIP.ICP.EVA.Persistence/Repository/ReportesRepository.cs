using Dapper;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Persistence;
using PCM.SIP.ICP.EVA.Domain.Entities;
using PCM.SIP.ICP.EVA.Persistence.Context;
using PCM.SIP.ICP.EVA.Transversal.Common;
using System.Data;

namespace PCM.SIP.ICP.EVA.Persistence.Repository
{
    public class ReportesRepository : IReportesRepository
    {
        private readonly DapperContext _context;

        public ReportesRepository(DapperContext context)
        {
            _context = context;
        }

        public Response<dynamic> ReporteTotalEntidades(ReporteParametros parameters, out string jsonTotalEntidades)
        {
            Response<dynamic> retorno = new Response<dynamic>();
            jsonTotalEntidades = string.Empty;

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_SEL_REPORTE_TOTALENTIDADES";

                    var param = new DynamicParameters();

                    param.Add("evaluacion_id", parameters.evaluacion_id);
                    param.Add("etapa_id", parameters.etapa_id);
                    param.Add("entidad_id", parameters.entidad_id);
                    param.Add("error", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    param.Add("message", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                    param.Add("jsonTotalEntidades", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);

                    var result = connection.QuerySingleOrDefault<dynamic>(query, param: param, commandType: CommandType.StoredProcedure);

                    retorno.Data = string.Empty;
                    retorno.Error = param.Get<bool?>("error") ?? false;
                    retorno.Message = param.Get<string>("message") ?? string.Empty;
                    jsonTotalEntidades = param.Get<string>("jsonTotalEntidades") ?? string.Empty;
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
