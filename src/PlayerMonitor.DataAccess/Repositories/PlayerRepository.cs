using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PlayerMonitor.Core;
using PlayerMonitor.Core.RepositoryInterfaces;
using PlayerMonitor.DataAccess;
using PlayerMonitor.DataAccess.Interfaces;

namespace PlayerMonitor.DataAccess.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly BaseApplicationDbContext _context;

        public PlayerRepository(BaseApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<PlayerModel> GetAllPlayers()
        {
            return _context.Players.ToList();
        }
    }
}
