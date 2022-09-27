using Mailer.Models;
using System.Runtime.InteropServices;

namespace Mailer.Repository
{
    public interface IMessageRepository:IRepository<MessageMail>
    {
        Task<IEnumerable<MessageMail>> GetRangeByReceiverAsync(string Receiver, DateTime time);
    }
}
