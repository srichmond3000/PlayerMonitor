using PlayerMonitor.Core;
using Microsoft.EntityFrameworkCore;
using PlayerMonitor.DataAccess.Interfaces;

namespace PlayerMonitor.DataAccess
{
    public class ApplicationDbContext : BaseApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerModel>()
                 .ToTable(nameof(PlayerModel));

            modelBuilder.Entity<PlayerModel>()
                .Property(p => p.Forename)
                .HasMaxLength(255);

            modelBuilder.Entity<PlayerModel>()
                .Property(p => p.Surname)
                .HasMaxLength(250);

            modelBuilder.Entity<PlayerModel>()
                .HasMany(p => p.Sessions)
                .WithOne(s => s.Player);

            base.OnModelCreating(modelBuilder);
        }
    }
}
