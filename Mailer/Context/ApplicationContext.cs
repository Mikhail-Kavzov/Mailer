using Mailer.Models;
using Microsoft.EntityFrameworkCore;

namespace Mailer.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<MessageMail> Messages { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
