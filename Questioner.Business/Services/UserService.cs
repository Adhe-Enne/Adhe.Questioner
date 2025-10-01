using Core.SharedServices;
using Questioner.Business.Services.Interfaces;
using Questioner.Data.Entities;
using Questioner.Repository.Repository.Interfaces;

namespace Questioner.Business.Services
{
    public class UserService(IUserRepository userRepository) : GenericService<User>(userRepository), IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
    }
}
