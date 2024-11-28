namespace JapaneseFoodShop.DTOs
{
    public class BaseResponse
    {
        public bool Success { get; set; } = true;
        public string? ErrorMessage { get; set; }

        public BaseResponse(bool success = true, string? errorMessage = null)
        {
            Success = success;
            ErrorMessage = errorMessage;
        }
    }

    public class BaseResponse<TEntity>
        where TEntity : class
    {
        public bool Success { get; set; } = true;
        public string? ErrorMessage { get; set; }
        public TEntity? Data { get; set; }

        public BaseResponse(bool success = true,TEntity data = null!, string? errorMessage = null)
        {
            Success = success;
            Data = data;
            ErrorMessage = errorMessage;
        }
    }
}
