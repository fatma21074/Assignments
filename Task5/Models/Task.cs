namespace Task5.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime dueDate { get; set; }

    }
}
