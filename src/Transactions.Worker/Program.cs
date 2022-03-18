using Serilog;
using Transactions.Worker;
using Transactions.Worker.Configurations;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        IConfigurationBuilder builder = new ConfigurationBuilder()
             .SetBasePath(hostContext.HostingEnvironment.ContentRootPath)
             .AddJsonFile("appsettings.json", true, true)
             .AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", true, true)
             .AddEnvironmentVariables();

        IConfiguration configuration = builder.Build();

        services.AddDependencies(configuration);
        services.AddLogger(configuration);
        services.AddHostedService<Worker>();
    })
    .UseSerilog()
    .Build();

await host.RunAsync();
