namespace Task10.Dtos
{
    public class UpdateTaskRequest
    {
        public string Title { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
