﻿using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PlayerMonitor.Core.RepositoryInterfaces;
using PlayerMonitor.DataAccess;
using PlayerMonitor.DataAccess.Interfaces;
using PlayerMonitor.DataAccess.Repositories;

namespace PlayerMonitor.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options =>
                    options.UseSqlServer(
                        "Server=WIN-08KTV2JGCK2\\SQLEXPRESS;Trusted_Connection=True;MultipleActiveResultSets=true;Database=PlayerMonitorTest"));
            
            services.AddSingleton<IPlayerRepository, PlayerRepository>();
            services.AddSingleton<ISessionRepository, SessionRepository>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            
            // Add framework services.
            services.AddMvc();

            var builder = new ContainerBuilder();
            builder.RegisterType<ApplicationDbContext>().As<BaseApplicationDbContext>();
            builder.Populate(services);
            var container = builder.Build();

            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
