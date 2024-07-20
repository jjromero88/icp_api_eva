using Dapper;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Persistence;
using PCM.SIP.ICP.EVA.Domain.Entities;
using PCM.SIP.ICP.EVA.Persistence.Context;
using PCM.SIP.ICP.EVA.Transversal.Common;
using PCM.SIP.ICP.EVA.Transversal.Common.Data;
using System.Data;

namespace PCM.SIP.ICP.EVA.Persistence.Repository
{
    public class ResultadoRepository : IResultadoRepository
    {
        private readonly DapperContext _context;

        public ResultadoRepository(DapperContext context)
        {
            _context = context;
        }

        public Response Insert(Resultado entidad)
        {
            Response retorno = new Response();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_INS_RESULTADO";

                    var parameters = new DynamicParameters();

                    parameters.Add("usuario_reg", entidad.usuario_reg);
                    parameters.Add("error", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    parameters.Add("message", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);

                    var resultadoTable = DataTableHelper.ConvertToDataTable(entidad.resultados ?? new List<TypeResultado>());
                    parameters.Add("RESULTADOS", resultadoTable.AsTableValuedParameter("UDT_RESULTADO"));

                    var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);

                    retorno.Error = parameters.Get<bool?>("error") ?? false;
                    retorno.Message = parameters.Get<string>("message") ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                retorno.Error = true;
                retorno.Message = ex.Message;
            }

            return retorno;
        }

        public Response Update(Resultado entidad)
        {
            throw new NotImplementedException();
        }

        public Response Delete(Resultado entidad)
        {
            throw new NotImplementedException();
        }

        public Response<dynamic> GetById(Resultado entidad)
        {
            throw new NotImplementedException();
        }

        public Response<List<dynamic>> GetList(Resultado entidad)
        {
            Response<List<dynamic>> retorno = new Response<List<dynamic>>();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_SEL_RESULTADO";

                    var parameters = new DynamicParameters();

                    parameters.Add("resultado_id", entidad.resultado_id.Equals(0) ? (int?)null : entidad.resultado_id);
                    parameters.Add("preguntaetapa_id", entidad.preguntaetapa_id);
                    parameters.Add("entidadetapa_id", entidad.entidadetapa_id);
                    parameters.Add("alternativa_id", entidad.alternativa_id);

                    parameters.Add("error", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    parameters.Add("message", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);

                    IEnumerable<dynamic> result = connection.Query<dynamic>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    List<dynamic> lista = result.ToList();

                    retorno.Data = lista;
                    retorno.Error = parameters.Get<bool?>("error") ?? false;
                    retorno.Message = parameters.Get<string>("message") ?? string.Empty;
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
