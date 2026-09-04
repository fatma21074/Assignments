using System.ComponentModel.DataAnnotations;

namespace Task12.DTOs
{
    public class Login
    {
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
