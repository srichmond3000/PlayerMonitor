using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlayerMonitor.DataAccess.Interfaces;
using PlayerMonitor.Core;
using PlayerMonitor.Core.RepositoryInterfaces;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private BaseApplicationDbContext _context;

        public UnitOfWork(IPlayerRepository playerRepository, ISessionRepository sessionRepository, BaseApplicationDbContext context)
        {
            _context = context;
            Players = playerRepository;
            Sessions = sessionRepository;
        }

        public IPlayerRepository Players { get; private set; }
        public ISessionRepository Sessions { get; private set; }
        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
