﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Novateca.Web
{
    public class Program
    {
        

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            //var host = BuildWebHost(args);
            //InitializeDatabase(host);
            //host.Run();
        }

        //public static IWebHost BuildWebHost(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>()
        //        .Build();

        //private static void InitializeDatabase(IWebHost host)
        //{
        //    using (var scope = host.Services.CreateScope())
        //    {
        //        var services = scope.ServiceProvider;

        //        try
        //        {
        //            SeedData.InitializeAsync(services).Wait();
        //        }
        //        catch (Exception ex)
        //        {
        //            var logger = services
        //                .GetRequiredService<ILogger<Program>>();
        //            logger.LogError(ex, "Error occurred seeding the DB.");
        //        }
        //    }
        //}

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
