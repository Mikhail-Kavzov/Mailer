using Mailer.Context;
using Mailer.Models;
using Microsoft.EntityFrameworkCore;

namespace Mailer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext db;

        public UserRepository(ApplicationContext applicationContext)
        {
            db = applicationContext;
        }

        public void Create(User item)
        {
            var user = db.Users.FirstOrDefault(u => u.Name == item.Name);
            if (user == null)
                db.Users.Add(item);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await db.Users.ToListAsync();
        }

        public async Task<IEnumerable<string?>> GetNamesAsync()
        {
            return await db.Users.Select(u => u.Name).ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
