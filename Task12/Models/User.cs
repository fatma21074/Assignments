using System.ComponentModel.DataAnnotations;
using System.Data;
using Task12.Enims;

namespace Task12.Models
{
    public class User
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
        public string PasswordHash { get; set; }

        public Role Role { get; set; } = Role.User;
        public Departments Department { get; set; } = Departments.HR;

        // Navigation Property
        public ICollection<TaskItem> TaskItems = new List<TaskItem>();
    }
}