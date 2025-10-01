using Core.Contracts;
using Core.Contracts.Model;
using Core.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Questioner.Data.Entities;
using Questioner.Repository.Repository;
using Questioner.Repository.Repository.Interfaces;

namespace Questioner.Repository
{
    public static class StartUp
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryAsync<BaseUser>, RepositoryAsync<BaseUser>>();
            services.AddScoped<IRepositoryAsync<User>, RepositoryAsync<User>>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
