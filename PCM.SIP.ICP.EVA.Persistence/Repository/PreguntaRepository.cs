using Dapper;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Persistence;
using PCM.SIP.ICP.EVA.Domain.Entities;
using PCM.SIP.ICP.EVA.Persistence.Context;
using PCM.SIP.ICP.EVA.Transversal.Common;
using System.Data;

namespace PCM.SIP.ICP.EVA.Persistence.Repository
{
    public class PreguntaRepository : IPreguntaRepository
    {
        private readonly DapperContext _context;

        public PreguntaRepository(DapperContext context)
        {
            _context = context;
        }

        public Response Insert(Pregunta entidad)
        {
            throw new NotImplementedException();
        }

        public Response Update(Pregunta entidad)
        {
            throw new NotImplementedException();
        }

        public Response Delete(Pregunta entidad)
        {
            throw new NotImplementedException();
        }

        public Response<dynamic> GetById(Pregunta entidad)
        {
            throw new NotImplementedException();
        }

        public Response<List<dynamic>> GetList(Pregunta entidad)
        {
            Response<List<dynamic>> retorno = new Response<List<dynamic>>();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_SEL_PREGUNTA_ENTIDAD";

                    var parameters = new DynamicParameters();

                    parameters.Add("evaluacionetapa_id", entidad.evaluacionetapa_id);
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
