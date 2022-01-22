﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinesLogic.Data;
using Core.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope()) {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();

                try
                {
                    var context = services.GetRequiredService<MarketDbContext>();
                    await context.Database.MigrateAsync();
                    await MarketDbContextData.LoadDataAsync(context, loggerFactory);

                    var userManager = services.GetRequiredService<UserManager<Usuario>>();
                    var identityContext = services.GetRequiredService<SeguridadDbContext>();
                    await identityContext.Database.MigrateAsync();
                    await SeguridadDbContextData.SeedUserAsync(userManager);
                }
                catch(Exception e)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(e.Message, "Error en el proceso de Migración");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

