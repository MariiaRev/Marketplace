namespace Contracts
{
    public class PagedData<T> where T: class
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<T> Value { get; set; } = new List<T>();
    }
}
