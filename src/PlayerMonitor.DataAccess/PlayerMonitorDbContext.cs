using PlayerMonitor.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerMonitor.DataAccess
{
    public class PlayerMonitorDbContext : DbContext
    {
        public PlayerMonitorDbContext (DbContextOptions options) : base(options)
        {
        }

        public DbSet<PlayerModel> Players { get; set; }
        public DbSet<SessionModel> Sessions { get; set; }

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
