using Microsoft.EntityFrameworkCore;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Dal
{
    public class MathDbContext:DbContext
    {
        public MathDbContext(DbContextOptions<MathDbContext> dbContextOptions):base(dbContextOptions)
        {

        }

        public DbSet<LogMethod> logMethods { get; set; }
        public DbSet<LogReport> logReports { get; set; }
    }
}
