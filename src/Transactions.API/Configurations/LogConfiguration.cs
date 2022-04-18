using Serilog;
using Serilog.Events;
using Microsoft.ApplicationInsights.Extensibility;

namespace Transactions.API.Configurations
{
    public static class LogConfiguration
    {
        public static void AddLogger(this IServiceCollection services, IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(configuration)
                    .MinimumLevel.Debug()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                    .MinimumLevel.Override("System", LogEventLevel.Error)
                    .Enrich.FromLogContext()
                    .Enrich.WithEnvironmentUserName()
                    .Enrich.WithMachineName()
                    .Enrich.WithProcessId()
                    .Enrich.WithProcessName()
                    .Enrich.WithThreadId()
                    .Enrich.WithThreadName()
                    .WriteTo.Console()
                    .WriteTo.ApplicationInsights(new TelemetryConfiguration { InstrumentationKey = configuration["ApplicationInsights:InstrumentationKey"] }, TelemetryConverter.Traces)
                .CreateLogger();

            services.AddSingleton(Log.Logger);
        }
    }
}
