using Core.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Questioner.Data.Configurations;
using Questioner.Data.Entities;

namespace Questioner.Infrastructure.Data
{
    public class QuestionerDbContext : BaseContext <QuestionerDbContext>
    {
        public QuestionerDbContext(DbContextOptions<QuestionerDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
    }
}
