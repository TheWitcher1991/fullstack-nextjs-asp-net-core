namespace backend.Domain.Abstractions
{
    public interface IToolkit
    {
        Guid getUserGuid(HttpContext? httpContext);
        string? getUserToken(HttpContext? httpContext);
    }
}