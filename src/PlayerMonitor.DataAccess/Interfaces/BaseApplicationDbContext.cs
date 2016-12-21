using Microsoft.EntityFrameworkCore;
using PlayerMonitor.Core;

namespace PlayerMonitor.DataAccess.Interfaces
{
    public abstract class BaseApplicationDbContext : DbContext
    {
        public BaseApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        DbSet<PlayerModel> Players { get; set; }
        DbSet<SessionModel> Sessions { get; set; }
    }
}