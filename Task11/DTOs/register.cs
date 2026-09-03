using System.ComponentModel.DataAnnotations;
using Task11.Enums;

namespace Task11.DTOs
{
    public class register
    {
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        public Role Role { get; set; } = Role.User;

    }
}
