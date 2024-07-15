using Dapper;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Persistence;
using PCM.SIP.ICP.EVA.Domain.Entities;
using PCM.SIP.ICP.EVA.Persistence.Context;
using PCM.SIP.ICP.EVA.Transversal.Common;
using System.Data;

namespace PCM.SIP.ICP.EVA.Persistence.Repository
{
    public class EvaluacionRepository : IEvaluacionRepository
    {
        private readonly DapperContext _context;

        public EvaluacionRepository(DapperContext context)
        {
            _context = context;
        }

        public Response Insert(Evaluacion entidad)
        {
            throw new NotImplementedException();
        }

        public Response Update(Evaluacion entidad)
        {
            throw new NotImplementedException();
        }

        public Response Delete(Evaluacion entidad)
        {
            throw new NotImplementedException();
        }

        public Response<dynamic> GetById(Evaluacion entidad)
        {
            throw new NotImplementedException();
        }

        public Response<List<dynamic>> GetList(Evaluacion entidad)
        {
            Response<List<dynamic>> retorno = new Response<List<dynamic>>();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_SEL_EVALUACION_ENTIDAD";

                    var parameters = new DynamicParameters();

                    parameters.Add("evaluacion_id", entidad.evaluacion_id.Equals(0) ? (int?)null : entidad.evaluacion_id);
                    parameters.Add("entidad_id", entidad.entidad_id);
                    parameters.Add("fecha_inicio", entidad.fecha_inicio);
                    parameters.Add("fecha_fin", entidad.fecha_fin);
                    parameters.Add("filtro", entidad.filtro);
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
