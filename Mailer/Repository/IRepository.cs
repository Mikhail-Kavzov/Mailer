using Mailer.Models;

namespace Mailer.Repository
{
    public interface IRepository<T>
    {
        void Create(T item);
        Task<IEnumerable<T>> GetAllAsync();
        Task SaveChangesAsync();
    }
}
