namespace Task6.Models
{
    public class TaskFilterParams:PaginationParams
    {
        public string? Search {  get; set; }
        public double? Price { get; set; }
        public bool? IsCompleted { get; set; }
        public string? SortBy { get; set; }
        public string? Order { get; set; } = "asc";
        public bool? CraetAfter {  get; set; }
        public bool? CraetBefore { get; set; }

    }
}
