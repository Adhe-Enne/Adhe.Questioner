using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Questioner.Infrastructure.Data;

namespace Questioner.Data
{
    public static class StartUp
    {
        public static void AddMySqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            int? mayor = configuration.GetValue<int>("DatabaseSettings:MySql:Mayor");
            int? min = configuration.GetValue<int>("DatabaseSettings:MySql:Min");
            int? build = configuration.GetValue<int>("DatabaseSettings:MySql:Build");

            ValidateConfiguration(connectionString, mayor, min, build);

            services.AddDbContext<DbContext, QuestionerDbContext>(options =>
                options.UseMySql(
                    connectionString, new MySqlServerVersion(new Version(mayor.Value, min.Value, build.Value)),
                    mySqlOptions => mySqlOptions.EnableRetryOnFailure()
                    )
                .EnableSensitiveDataLogging()
                );
        }

        private static void ValidateConfiguration(string? connectionString, int? mayor, int? min, int? build)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("La cadena de conexión 'DefaultConnection' no está definida en el archivo de configuración.");
            }

            if (mayor is null || min is null || build is null)
            {
                throw new InvalidOperationException("Los parámetros de versión de MySQL (Mayor, Min, Build) deben estar definidos en el archivo de configuración.");
            }
        }
    }
}
