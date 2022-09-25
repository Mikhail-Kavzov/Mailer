using Mailer.Models;
using System.Runtime.InteropServices;

namespace Mailer.Repository
{
    public interface IMessageRepository
    {
        void Create(MessageMail item);
        Task<IEnumerable<MessageMail>> GetAllAsync();
        Task<IEnumerable<MessageMail>> GetRangeByReceiverAsync(string Receiver, DateTime time);
        Task SaveChangesAsync();
    }
}
