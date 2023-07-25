using CoreX.Domain;
using CoreX.Settings;
using EntityFrameworkCore.CoreX;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using SoftDeleteServices.Configuration;
using System.Reflection;

namespace CoreX.AppConfigurator
{
    public static class DatabaseConfigurator
    {
        public static void AddDatabaseService<
            TDbContext,
            TDatabase,
            TDbTransaction,
            TDeletabilityConfiguration>(
            this IServiceCollection services,
            DatabaseSettings databaseSettings)
            where TDbContext : DbContext
            where TDatabase : Database
            where TDbTransaction : DbTransaction
            where TDeletabilityConfiguration : CascadeSoftDeleteConfiguration<ISoftDelete>
        {
            services.AddDatabaseService<TDbContext, TDatabase, TDbTransaction>(databaseSettings);

            services.RegisterSoftDelServicesAndYourConfigurations(
                Assembly.GetAssembly(typeof(TDeletabilityConfiguration)));
        }

        public static void AddDatabaseService<
            TDbContext,
            TDatabase,
            TDbTransaction>(
            this IServiceCollection services,
            DatabaseSettings databaseSettings)
            where TDbContext : DbContext
            where TDatabase : Database
            where TDbTransaction : DbTransaction
        {
            services.AddDatabaseService<TDbContext>(databaseSettings);

            // Database Registrations
            services.AddScoped<IDatabase, TDatabase>();
            services.AddScoped<IDbTransaction, TDbTransaction>();
        }

        public static void AddDatabaseService<TDbContext>(
            this IServiceCollection services,
            DatabaseSettings databaseSettings)
            where TDbContext : DbContext
        {
            if (databaseSettings.UsingBy == DatabaseType.InMemory)
            {
                services.AddDbContext<TDbContext>(options =>
                   options.UseInMemoryDatabase("mydb")
                   .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning)),
                   ServiceLifetime.Scoped);
            }
            else if (databaseSettings.UsingBy == DatabaseType.SqlServer)
            {
                services.AddDbContext<TDbContext>(options =>
                   options.UseSqlServer(databaseSettings.SqlServerConnectString),
                   ServiceLifetime.Scoped);
            }
            else if (databaseSettings.UsingBy == DatabaseType.MongoDb)
            {
            }
        }
    }
}
