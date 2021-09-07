﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProcurementTracker.Data;
using ProcurementTracker.Models.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcurementTracker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var dbConnectionString = GetDatabaseConnectionString();
            if (dbConnectionString == null)
                throw new NullReferenceException("Database connection string has not been set");

            services.AddDbContext<ProcurementTrackerContext>(options =>
                    options.UseSqlServer(dbConnectionString));

            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddRazorPages();
            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/Procurements/Index", "");
                options.Conventions.AuthorizeFolder("/Procurements");
            }).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);

            services.AddTransient<ISupplierManager, SupplierManager>();
        }

        private static string? GetDatabaseConnectionString()
        {
            string? connectionString = null;

            string? dbHost = Environment.GetEnvironmentVariable("PROCUREMENT_TRACKER_DB_HOST");
            string? db = Environment.GetEnvironmentVariable("PROCUREMENT_TRACKER_DB");
            string? dbUser = Environment.GetEnvironmentVariable("PROCUREMENT_TRACKER_DB_USER");
            string? dbPassword = Environment.GetEnvironmentVariable("PROCUREMENT_TRACKER_DB_PASSWORD");

            if (dbHost is not null && db is not null && dbUser is not null && dbPassword is not null)
                connectionString = $"Server={dbHost};Initial Catalog={db};User Id={dbUser};Password={dbPassword};Integrated Security=False;";

            return connectionString;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
