namespace JapaneseFoodShop.DTOs.Responses
{
    public class DataListResponse<T>
    {
        public bool Success { get; set; } = true;
        public string? ErrorMessage { get; set; }
        public IEnumerable<T> Data { get; set; }

        public DataListResponse(bool success = true, IEnumerable<T> data = null!, string? errorMessage = null)
        {
            Success = success;
            ErrorMessage = errorMessage;
            Data = data;
        }
    }
}
