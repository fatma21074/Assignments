using System.ComponentModel.DataAnnotations;
using Task12.Enims;

namespace Task12.DTOs
{
    public class Register
    {
        public int Id { get; set; } = 0;

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        public Role Role { get; set; } = Role.User;
        public Departments Department { get; set; } = Departments.HR;
    }
}
