using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class PlayerMonitorDbContextFactory : IDbContextFactory<PlayerMonitorDbContext>
    {
        public PlayerMonitorDbContext Create (DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<PlayerMonitorDbContext>();
            builder.UseSqlServer("Server=WIN-08KTV2JGCK2\\SQLEXPRESS;Trusted_Connection=True;MultipleActiveResultSets=true;Database=PlayerMonitorTest");

            return new PlayerMonitorDbContext(builder.Options);
        }
    }
}
