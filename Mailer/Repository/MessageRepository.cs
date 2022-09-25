using Mailer.Context;
using Mailer.Models;
using Microsoft.EntityFrameworkCore;

namespace Mailer.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationContext db;

        public MessageRepository(ApplicationContext appContext)
        {
            db = appContext;
        }

        public void Create(MessageMail item)
        {
            db.Messages.Add(item);
        }

        public async Task<IEnumerable<MessageMail>> GetAllAsync()
        {
            return await db.Messages.ToListAsync();
        }

        public async Task<IEnumerable<MessageMail>> GetRangeByReceiverAsync(string Receiver, DateTime time)
        {
            return await db.Messages.Where(m => m.Receiver == Receiver && m.Time > time).ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
