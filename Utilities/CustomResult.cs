using Microsoft.AspNetCore.Http.HttpResults;

namespace EmployeeManagementSystemWeb.Utilities
{
    public class CustomResult<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string Message { get; set; } = string.Empty;

        public static CustomResult<T> Ok(T data, string message = null)
        {
            return new CustomResult<T>
            {
                Success = true,
                Data = data,
                Message = message
            };
        }

        public static CustomResult<T> Fail(string message = null)
        {
            return new CustomResult<T>
            {
                Success = false,
                Message = message
            };
        }
    }
}
