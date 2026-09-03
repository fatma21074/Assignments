using System.ComponentModel.DataAnnotations;

namespace Task11.DTOs
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
