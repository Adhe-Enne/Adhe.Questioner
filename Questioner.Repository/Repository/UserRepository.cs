using Core.Infrastructure;
using Questioner.Data.Entities;
using Questioner.Infrastructure.Data;
using Questioner.Repository.Repository.Interfaces;

namespace Questioner.Repository.Repository
{
    public class UserRepository : GenericRepositoryAsync<User>, IUserRepository
    {
        public UserRepository(QuestionerDbContext dbContext) : base(dbContext) { }
    }
}
