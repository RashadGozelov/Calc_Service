using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Web;
using Project.Dal;
using Project.Models;  

namespace Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var log = NLogBuilder.ConfigureNLog("Nlog.config").GetCurrentClassLogger();
            try
            {
                log.Debug("Starting app");
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Happened exception");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }


            var WebHostBuilder = CreateWebHostBuilder(args).Build();
            using (var scope = WebHostBuilder.Services.CreateScope())
            {
                using (var mathdb = scope.ServiceProvider.GetRequiredService<MathDbContext>())
                {
                    var transaction = mathdb.Database.BeginTransaction();

                    try
                    {

                        for (int i = 1; i <= 4; i++)
                        {
                            if (!mathdb.logMethods.Any(m => m.Id == i))
                            {
                                mathdb.logMethods.Add(new LogMethod
                                {
                                    Id = i,
                                    InsertDate = DateTime.Now,
                                });
                            }
                        }

                        mathdb.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                    finally
                    {
                        transaction.Dispose();
                    }
                }
            }
            WebHostBuilder.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
          WebHost.CreateDefaultBuilder(args)
              .UseStartup<Startup>()
                 .ConfigureLogging(logging =>
                 {
                     logging.ClearProviders();
                     logging.SetMinimumLevel(LogLevel.Trace);
                 })
                   .UseNLog();
    }
}
