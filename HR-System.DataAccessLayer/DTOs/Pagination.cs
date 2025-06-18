namespace HR_System.DataAccessLayer.DTOs
{
    public class Pagination<TEntity> where TEntity : class
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public IEnumerable<TEntity> Items { get; set; }
    }
}
