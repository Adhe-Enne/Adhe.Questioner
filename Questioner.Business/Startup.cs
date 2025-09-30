using Core.SharedServices;
using Microsoft.Extensions.DependencyInjection;
using Questioner.Business.Services;
using Questioner.Business.Services.Interfaces;
using Questioner.Data.Entities;

namespace Questioner.Business
{
    public static class Startup
    {
        public static void AddServicesBusiness(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
