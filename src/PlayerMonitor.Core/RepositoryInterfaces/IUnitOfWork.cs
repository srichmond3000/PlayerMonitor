namespace PlayerMonitor.Core.RepositoryInterfaces
{
    public interface IUnitOfWork
    {
        IPlayerRepository Players { get; }
        ISessionRepository Sessions { get; }
        void Complete();
    }
}
