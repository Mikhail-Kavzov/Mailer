namespace Mailer.Models
{
    public class MessageMail
    {
        public int Id { get; set; }
        public string? Sender { get; set; }
        public string? Receiver { get; set; }
        public DateTime Time { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
    }
}
