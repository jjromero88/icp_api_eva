using PCM.SIP.ICP.EVA.Aplicacion.Interface;

namespace PCM.SIP.ICP.EVA.Persistence.Repository.Base
{
    public class UnitOfWork: IUnitOfWork
    {
        public UnitOfWork() { }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
