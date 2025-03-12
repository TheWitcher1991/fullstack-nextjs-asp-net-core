using Microsoft.AspNetCore.Mvc;

namespace backend.Response
{
    public record ResponseError(string? ErrorCode, string? ErrorMessage, string? InvalidField);

    public record Envelope<T>
    {
        private Envelope(T? result, IEnumerable<ResponseError> errors)
        {
            Result = result;
            Errors = errors.ToList();
            TimeGenerated = DateTime.UtcNow;
        }

        public T? Result { get; }
        public List<ResponseError> Errors { get; } = new();
        public DateTime TimeGenerated { get; }

        public static Envelope<T> Ok(T? result = default)
        {
            return new Envelope<T>(result, new List<ResponseError>());
        }

        public static Envelope<T> Error(IEnumerable<ResponseError> errors)
        {
            return new Envelope<T>(default, errors);
        }

        public static Envelope<T> Error(ResponseError error)
        {
            return new Envelope<T>(default, new List<ResponseError> { error });
        }

        public static implicit operator ActionResult<Envelope<T>>(Envelope<T> envelope)
        {
            return new OkObjectResult(envelope);
        }
    }
}
