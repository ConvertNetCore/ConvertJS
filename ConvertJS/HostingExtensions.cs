using ConvertJS.DTOs.Configuration;
using ConvertJS.Services.AccountServices;
using ConvertJS.Services.AdSpyServices;
using ConvertJS.Services.AppealCheckServices;
using ConvertJS.Services.HomeServices;
using ConvertJS.Services.RulesServices;

using Serilog;

namespace ConvertJS
{
    public static class HostingExtensions
    {
        private const string MyAllowSpecificOrigins = "AllowOrigin";
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            //builder.Host.ConfigureAppConfiguration((hostingContext, config) => { AppSettings.Instance.SetConfiguration(hostingContext.Configuration); });
            builder.Host.UseSerilog((hostContext, services, configuration) =>
            {
                configuration.ReadFrom.Configuration(hostContext.Configuration);
            });
            builder.Services.AddControllersWithViews();


            builder.Services.AddHttpContextAccessor();
            builder.Services.AddHttpClient();
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHealthChecks();
            //builder.Services.AddScoped<IRulesService, RulesService>();
            builder.Services.AddScoped<IAccountService,AccountService>();
            builder.Services.AddScoped<IAdSpyService,AdSpyService>();
            builder.Services.AddScoped<IAppealCheckService , AppealCheckService>();
            builder.Services.AddScoped<IHomeService, HomeService>();
            
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
            app.UseStaticFiles(); // Đảm bảo đã đăng ký Middleware Static Files
            app.UseSerilogRequestLogging();

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
                    await context.Response.WriteAsync("[API] Convert");
                });
            });

            app.MapControllers();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

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
