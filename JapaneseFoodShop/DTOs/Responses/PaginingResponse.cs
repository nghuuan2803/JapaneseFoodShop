namespace JapaneseFoodShop.DTOs
{

    public class PaginingResponse<TEntity>
        where TEntity : class
    {
        public IEnumerable<TEntity>? Data { get; set; }

        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public bool Success { get; set; } = true;
        public string? ErrorMessage { get; set; }

        public PaginingResponse(IEnumerable<TEntity>? data, int totalItems, int totalPages, bool success, string? errorMessage)
        {
            Data = data;
            TotalItems = totalItems;
            TotalPages = totalPages;
            Success = success;
            ErrorMessage = errorMessage;
        }
    }
}
