using PCM.SIP.ICP.EVA.Aplicacion.Interface;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Persistence;

namespace PCM.SIP.ICP.EVA.Persistence.Repository.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEvaluacionRepository Evaluacion { get; }
        public IPreguntaRepository Pregunta { get; }
        public IPreguntaEtapaRepository PreguntaEtapa { get; }
        public IResultadoRepository Resultado { get; }
        public IDocumentRepository Document { get; }
        public IEntidadEtapaRepository EntidadEtapa { get; }

        public UnitOfWork(
            IEvaluacionRepository evaluacion,
            IPreguntaRepository pregunta,
            IPreguntaEtapaRepository preguntaEtapa,
            IResultadoRepository resultado,
            IDocumentRepository document,
            IEntidadEtapaRepository entidadEtapa
            )
        {
            Evaluacion = evaluacion;
            Pregunta = pregunta;
            PreguntaEtapa = preguntaEtapa;
            Resultado = resultado;
            Document = document;
            EntidadEtapa = entidadEtapa;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
