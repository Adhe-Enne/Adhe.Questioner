using Core.SharedServices;
using Core.SharedServices.Authentication;
using Core.SharedServices.Security.Interfaces;
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
            services.AddScoped(typeof(IGenericService<User>), typeof(GenericService<User>));
            
            services.AddScoped<IUserService, UserService>();
            services.AddScoped(typeof(IAuthenticationService<User>), typeof(AuthenticationService<User>));
            services.AddScoped(typeof(IPasswordHasherService<User>), typeof(Core.SharedServices.Security.PasswordHasherService<User>));
            services.AddScoped(typeof(ITokenService<User>), typeof(Core.SharedServices.Security.TokenService<User>));
        }
    }
}
