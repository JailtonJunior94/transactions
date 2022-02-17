using Transactions.Core.Infra.Contexts;
using Transactions.Core.Domain.Handlers;
using Transactions.Core.Infra.Repositories;
using Transactions.Core.Infra.Mappings.Setup;
using Transactions.Core.Domain.Interfaces.Handlers;
using Transactions.Core.Domain.Interfaces.Contexts;
using Transactions.Core.Domain.Interfaces.Repositories;

namespace Transactions.Worker.Configurations
{
    public static class DependenciesConfiguration
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            /* Context */
            services.AddSingleton<IMongoDbContext>(m => new MongoDbContext(configuration["ConnectionsString:MongoDB"], configuration["MongoDB:DatabaseName"]));
            SetupMaps.ConfigureMaps();

            /* Repositories */
            services.AddSingleton<ISummaryRepository, SummaryRepository>();
            services.AddSingleton<ISummarySQLRepository, SummarySQLRepository>();

            /* Handlers */
            services.AddSingleton<ISummaryHandle, SummaryHandle>();
        }
    }
}
