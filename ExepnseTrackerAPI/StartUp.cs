using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ExepnseTrackerAPI.Models;
using ExepnseTrackerAPI.Services;

namespace ExpenseTrackerAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configure CORS policy
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            // Add framework services.
            services.AddControllers();

            // Add DbContext using SQL Server Provider
            var connectionString = GetConnectionString();
            services.AddDbContext<ExpenseDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddSwaggerGen();

            // Register ClsUser as a scoped service
            services.AddScoped<ClsUser>();
            services.AddScoped<ExpenseService>();
            services.AddScoped<ClsUIColumnConfig>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExpenseTrackerAPI V1");
                    c.DefaultModelExpandDepth(-1);
                    c.DefaultModelsExpandDepth(-1);
                });
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            // Apply CORS policy
            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private string GetConnectionString()
        {
            var server = Configuration["DatabaseConfig:Server"];
            var database = Configuration["DatabaseConfig:Database"];
            //var userId = Configuration["DatabaseConfig:UserId"];
            //var password = Configuration["DatabaseConfig:Password"];
            return $"Server={server};Database={database};TrustServerCertificate=True;";
        }
    } 
}
