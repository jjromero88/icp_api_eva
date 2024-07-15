using PCM.SIP.ICP.EVA.Aplicacion.Interface;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Persistence;

namespace PCM.SIP.ICP.EVA.Persistence.Repository.Base
{
    public class UnitOfWork: IUnitOfWork
    {
        public IEvaluacionRepository Evaluacion { get; }

        public UnitOfWork(
            IEvaluacionRepository evaluacion
            ) {
            Evaluacion = evaluacion;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
