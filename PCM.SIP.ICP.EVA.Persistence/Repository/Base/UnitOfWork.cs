using PCM.SIP.ICP.EVA.Aplicacion.Interface;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Persistence;

namespace PCM.SIP.ICP.EVA.Persistence.Repository.Base
{
    public class UnitOfWork: IUnitOfWork
    {
        public IEvaluacionRepository Evaluacion { get; }
        public IPreguntaRepository Pregunta {  get; }

        public UnitOfWork(
            IEvaluacionRepository evaluacion,
            IPreguntaRepository pregunta
            ) {
            Evaluacion = evaluacion;
            Pregunta = pregunta;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
