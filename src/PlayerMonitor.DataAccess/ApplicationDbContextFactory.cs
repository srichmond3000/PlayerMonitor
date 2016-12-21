using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlayerMonitor.DataAccess.Interfaces;

namespace PlayerMonitor.DataAccess
{
    public class ApplicationDbContextFactory : IDbContextFactory<BaseApplicationDbContext>, IApplicationDbContextFactory
    {
        public BaseApplicationDbContext Create (DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseSqlServer("Server=WIN-08KTV2JGCK2\\SQLEXPRESS;Trusted_Connection=True;MultipleActiveResultSets=true;Database=PlayerMonitorTest");

            return new ApplicationDbContext(builder.Options);
        }
    }
}
 