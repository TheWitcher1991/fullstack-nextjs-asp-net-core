using System.Text.Json.Serialization;

namespace backend.Shared.Core
{
    public record Envelope
    {
        public object? Result { get; }

        public ErrorList? Errors { get; }

        public bool IsError => Errors != null || Errors != null && Errors.Any();

        public DateTime TimeGenerated { get; }

        [JsonConstructor]
        private Envelope(object? result, ErrorList? errors)
        {
            Result = result;
            Errors = errors;
            TimeGenerated = DateTime.Now;
        }

        public static Envelope Ok(object? result = null)
        {
            return new(result, null);
        }

        public static Envelope Error(ErrorList errors)
        {
            return new(null, errors);
        }
    }

    public record Envelope<T>
    {
        public T? Result { get; }

        public ErrorList? Errors { get; }

        public bool IsError => Errors != null || Errors != null && Errors.Any();

        public DateTime TimeGenerated { get; }

        [JsonConstructor]
        private Envelope(T? result, ErrorList? errors)
        {
            Result = result;
            Errors = errors;
            TimeGenerated = DateTime.UtcNow;
        }

        public static Envelope<T> Ok(T? result = default)
        {
            return new(result, null);
        }

        public static Envelope<T> Error(ErrorList errors)
        {
            return new(default, errors);
        }
    }
}