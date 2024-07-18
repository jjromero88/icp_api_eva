using PCM.SIP.ICP.EVA.Aplicacion.Interface.Persistence;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IDocumentRepository Document { get; }
        IEvaluacionRepository Evaluacion { get; }
        IPreguntaRepository Pregunta { get; }
        IPreguntaEtapaRepository PreguntaEtapa { get; }
        IResultadoRepository Resultado { get; }
    }

}
