namespace JapaneseFoodShop.DTOs
{
    public class PaginingResult<T>
        where T : class
    {
        public IEnumerable<T> Data { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }
}
