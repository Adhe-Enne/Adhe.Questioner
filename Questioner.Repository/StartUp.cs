using Microsoft.Extensions.DependencyInjection;
using Questioner.Repository.Repository;
using Questioner.Repository.Repository.Interfaces;

namespace Questioner.Repository
{
    public static class StartUp
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
