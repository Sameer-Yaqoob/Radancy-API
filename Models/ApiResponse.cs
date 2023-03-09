using System.ComponentModel.DataAnnotations.Schema;

namespace MyApi.Models
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }
}