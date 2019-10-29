using Project.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Extentions
{
    public static class MathExtentions
    {
        public async static Task AddLog(this MathDbContext db, int type, string message)
        {
            await db.logReports.AddAsync(new Models.LogReport
            {
                InsertDate = DateTime.Now,
                LogMethodId = type,
                Value = message
            });

            await db.SaveChangesAsync();
        }
    }
}
