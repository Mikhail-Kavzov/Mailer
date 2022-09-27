using Mailer.Models;

namespace Mailer.Repository
{
    public interface IUserRepository:IRepository<User>
    {
        Task<IEnumerable<string?>> GetNamesAsync();
    }
}
