using System.ComponentModel.DataAnnotations;

namespace Mailer.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter your name")]
        public string Name { get; set; } = null!;
    }
}
