
namespace Models.DTO
{
    public class PagedResult<T>
    {
        public int TotalRecords { get; set; }
        public List<T>? Results { get; set; }
    }
}
