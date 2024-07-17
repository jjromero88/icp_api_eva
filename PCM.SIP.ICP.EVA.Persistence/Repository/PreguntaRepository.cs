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
            throw new NotImplementedException();
        }
    }
}
