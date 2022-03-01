using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GM.Infrastructure.InfraCore.Data
{
    public static class ConfigureDatabaseServices
    {

        public static void Configure(IServiceCollection services, string env, string dbType, string connectionString)
        {
            switch (env)
            {
                case "Development":
                    ConfigureDevelopmentDatabase(services, dbType, connectionString);
                    break;
                case "Production":
                case "Staging":
                    ConfigurePostgresDatabase(services, connectionString);
                    break;
                case "Testing":
                    ConfigureInMemoryDatabase(services);
                    break;
            }
        }

        private static void ConfigureDevelopmentDatabase(IServiceCollection services, string dbType, string connectionString)
        {
            switch (dbType.ToLower())
            {
                case "inmemory":
                    ConfigureInMemoryDatabase(services);
                    break;
                case "sqlite":
                    ConfigureSQLiteInMemoryDatabase(services);
                    break;
                case "postgres":
                    ConfigurePostgresDatabase(services, connectionString);
                    break;
                case "iisexpress":
                default:
                    ConfigureIisExpressDatabase(services, connectionString);
                    break;
            }
        }

        private static void ConfigureIisExpressDatabase(IServiceCollection services, string connectionString)
        {
            // For development, LocalDB which can be installed with SQL Server Express 2016
            // https://www.microsoft.com/en-us/download/details.aspx?id=54284
            services.AddDbContext<ApplicationDbContext>(c =>
                c.UseSqlServer(connectionString,
                x => x.MigrationsAssembly("WebApp")));
        }

        private static void ConfigurePostgresDatabase(IServiceCollection services, string connectionString)
        {
            // For staging, we are building a container and connecting to a Postgres database container
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

            // Specifying the MigrationsAssemply for the IisExpress provider allows us to run
            // simpler "dotnet ef" commands. But doing it for the UseNpgsql provider causes migrations to fail.
            //services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString,
            //    x => x.MigrationsAssembly("WebApp")));
        }

        private static void ConfigureInMemoryDatabase(IServiceCollection services)
        {
            // use in-memory database - not relational, does not support transactions, cannot run raw SQL queries
            services.AddDbContext<ApplicationDbContext>(c =>
                c.UseInMemoryDatabase("govmeeting"));
        }

        private static void ConfigureSQLiteInMemoryDatabase(IServiceCollection services)
        {
            // use SQLite in-memory database - a full relational database
            var connectionStringBuilder =
              new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            services.AddDbContext<ApplicationDbContext>(c =>
                c.UseSqlite(connection));
        }


    }
}
