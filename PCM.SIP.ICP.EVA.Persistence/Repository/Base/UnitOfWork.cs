namespace PCM.SIP.ICP.EVA.Persistence.Repository.Base
{
    public class UnitOfWork
    {
        public UnitOfWork() { }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
