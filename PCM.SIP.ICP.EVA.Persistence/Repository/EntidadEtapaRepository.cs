using Dapper;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Persistence;
using PCM.SIP.ICP.EVA.Domain.Entities;
using PCM.SIP.ICP.EVA.Persistence.Context;
using PCM.SIP.ICP.EVA.Transversal.Common;
using System.Data;

namespace PCM.SIP.ICP.EVA.Persistence.Repository
{
    public class EntidadEtapaRepository : IEntidadEtapaRepository
    {
        private readonly DapperContext _context;

        public EntidadEtapaRepository(DapperContext context)
        {
            _context = context;
        }

        public Response GenerarFicha(EntidadEtapa entidad)
        {
            Response retorno = new Response();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_UPD_ENTIDADETAPA_GENERAFICHA";

                    var parameters = new DynamicParameters();

                    parameters.Add("entidadetapa_id", entidad.entidadetapa_id);
                    parameters.Add("usuario_id", entidad.fichahistorico?.usuario_id);
                    parameters.Add("perfil_id", entidad.fichahistorico?.perfil_id);
                    parameters.Add("comentarios", entidad.fichahistorico?.comentarios);
                    parameters.Add("usuario_act", entidad.usuario_act);
                    parameters.Add("error", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    parameters.Add("message", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);

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

        public Response AprobarFicha(EntidadEtapa entidad)
        {
            Response retorno = new Response();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_UPD_ENTIDADETAPA_APRUEBAFICHA";

                    var parameters = new DynamicParameters();

                    parameters.Add("entidadetapa_id", entidad.entidadetapa_id);
                    parameters.Add("usuario_id", entidad.fichahistorico?.usuario_id);
                    parameters.Add("perfil_id", entidad.fichahistorico?.perfil_id);
                    parameters.Add("comentarios", entidad.fichahistorico?.comentarios);
                    parameters.Add("usuario_act", entidad.usuario_act);
                    parameters.Add("error", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    parameters.Add("message", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);

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

        public Response Firmarficha(EntidadEtapa entidad)
        {
            Response retorno = new Response();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = "dbo.USP_UPD_ENTIDADETAPA_FIRMAFICHAOFICIAL";

                    var parameters = new DynamicParameters();

                    parameters.Add("entidadetapa_id", entidad.entidadetapa_id);
                    parameters.Add("usuario_id", entidad.fichahistorico?.usuario_id);
                    parameters.Add("perfil_id", entidad.fichahistorico?.perfil_id);
                    parameters.Add("comentarios", entidad.fichahistorico?.comentarios);
                    parameters.Add("historico_doc", entidad.fichahistorico?.historicodocumento?.historico_doc);
                    parameters.Add("usuario_act", entidad.usuario_act);
                    parameters.Add("error", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    parameters.Add("message", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);

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
    }
}
