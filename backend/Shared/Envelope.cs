using Microsoft.AspNetCore.Mvc;

namespace backend.Shared
{
    public record ResponseError(string? ErrorCode, string? ErrorMessage, string? InvalidField);

    public record Envelope<T>
    {
        private Envelope(T? result, List<Error> errors)
        {
            Result = result;
            Errors = errors.ToList();
            TimeGenerated = DateTime.UtcNow;
        }

        public T? Result { get; }
        public List<Error> Errors { get; } = new();
        public DateTime TimeGenerated { get; }

        public static Envelope<T> Ok(T? result = default)
        {
            return new Envelope<T>(result, new List<Error>());
        }

        public static Envelope<T> Error(List<Error> errors)
        {
            return new Envelope<T>(default, errors);
        }

        public static Envelope<T> Error(Error error)
        {
            return new Envelope<T>(default, new List<Error> { error });
        }

        public static implicit operator ActionResult<Envelope<T>>(Envelope<T> envelope)
        {
            return new OkObjectResult(envelope);
        }
    }
}
