﻿using ConvertJS.DTOs.Configuration;
using Serilog;

namespace ConvertJS
{
    public static class HostingExtensions
    {
        private const string MyAllowSpecificOrigins = "AllowOrigin";
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Host.ConfigureAppConfiguration((hostingContext, config) => { AppSettings.Instance.SetConfiguration(hostingContext.Configuration); });
            builder.Host.UseSerilog((hostContext, services, configuration) =>
            {
                configuration.ReadFrom.Configuration(hostContext.Configuration);
            });
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddHttpClient();
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHealthChecks();

            var str = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddMemoryCache();
            builder.Services.AddCors(o => o.AddPolicy("AllowOrigin", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            builder.Services.AddAuthorization();

            builder.Services.AddHealthChecks();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseSerilogRequestLogging();
            //if use DB
            //InitializeDatabase(app);

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/friend/healthy");
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("[API] Friend");
                });
            });

            return app;
        }
        /// <summary>
        /// using if has database auto migration
        /// </summary>
        /// <param name="app"></param>
        //private static async void InitializeDatabase(IApplicationBuilder app)
        //{
        //    using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
        //    {
        //        var utcNow = DateTime.UtcNow;
        //        var context = serviceScope.ServiceProvider.GetService<CodelearnFriendContext>();
        //        await context.Database.MigrateAsync();
        //    }
        //}
    }
}