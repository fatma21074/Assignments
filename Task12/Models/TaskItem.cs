namespace Task12.Models
{
    public class TaskItem
    {
        public int Id { get; set; } = 0;
        public string Title { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }

        // Navigation Property
        public User? User { get; set; }
    }
}
