using Transactions.Core.Infra.Contexts;
using Transactions.Core.Infra.Repositories;
using Transactions.Core.Infra.Mappings.Setup;
using Transactions.Core.Application.Services;
using Transactions.Core.Domain.Interfaces.Services;
using Transactions.Core.Domain.Interfaces.Contexts;
using Transactions.Core.Domain.Interfaces.Repositories;

namespace Transactions.API.Configurations
{
    public static class DependenciesConfiguration
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            /* MongoContext */
            services.AddSingleton<IMongoDbContext>(m => new MongoDbContext(configuration["ConnectionsString:MongoDB"], configuration["MongoDB:DatabaseName"]));
            SetupMaps.ConfigureMaps();

            /* Repositories */
            services.AddScoped<ITransactionSQLRepository, TransactionSQLRepository>();
            services.AddScoped<ISummaryRepository, SummaryRepository>();

            /* Services */
            services.AddScoped<ITransactionService, TransactionService>();
        }
    }
}
