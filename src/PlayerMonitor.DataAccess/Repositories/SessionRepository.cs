using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlayerMonitor.Core.RepositoryInterfaces;
using PlayerMonitor.DataAccess;
using PlayerMonitor.DataAccess.Interfaces;

namespace PlayerMonitor.DataAccess.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly BaseApplicationDbContext _context;

        public SessionRepository(BaseApplicationDbContext context)
        {
            _context = context;
        }
    }
}
