using System.ComponentModel.DataAnnotations;

namespace Mailer.Models
{
    public class MessageViewModel
    {
        [Required(ErrorMessage = "Enter receiver")]
        public string? Receiver { get; set; }
        [Required(ErrorMessage = "Enter title")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Enter message")]
        public string? Body { get; set; }
    }
}
