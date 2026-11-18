using System.Net;

namespace Application.Response;

public class ApiResponse<T>
{
    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; } = null!;
    public T? Data { get; set; }
    public ApiResponse(HttpStatusCode status, string message, T data)
    {
        StatusCode = status;
        Message = message;
        Data = data;
    }
    public ApiResponse(HttpStatusCode status, string message)
    {
        StatusCode = status;
        Message = message;
    }
}
