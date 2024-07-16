using PCM.SIP.ICP.EVA.Aplicacion.Interface.Persistence;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IEvaluacionRepository Evaluacion { get; }
        IPreguntaRepository Pregunta { get; }
    }

}
