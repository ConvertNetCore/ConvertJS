using Serilog;

namespace ConvertJS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.ConfigureServices();

            var app = builder.Build().ConfigurePipeline();
            //Log.Logger.Error("Start API");

            app.Run();
        }
    }
}