using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PlayerMonitor.Core.RepositoryInterfaces;
using PlayerMonitor.DataAccess;
using PlayerMonitor.DataAccess.Interfaces;

namespace Data.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly BaseApplicationDbContext _context;

        public PlayerRepository(BaseApplicationDbContext context)
        {
            _context = context;
        }
    }
}
