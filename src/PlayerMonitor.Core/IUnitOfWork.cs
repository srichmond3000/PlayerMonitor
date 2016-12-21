using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlayerMonitor.Core.RepositoryInterfaces;

namespace PlayerMonitor.Core
{
    public interface IUnitOfWork
    {
        IPlayerRepository Players { get; }
        ISessionRepository Sessions { get; }
        void Complete();
    }
}
