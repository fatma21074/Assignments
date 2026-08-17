namespace Task6.Models
{
    public class PaginationParams
    {
        private const int MaxPageSize = 100;

        private int _pageSize = 5;
        public int Page { get; set; } = 1;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value < 1 ? 5 : (value > MaxPageSize ? MaxPageSize : value);

        }

    }
}
