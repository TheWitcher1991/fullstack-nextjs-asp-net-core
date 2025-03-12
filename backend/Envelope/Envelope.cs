namespace backend.Envelope
{
    public record ResponseError(string? ErrorCode, string? ErrorMessage, string? InvalidField);

    public record Envelope<T == object>
    {
        private Envelope(T? result, IEnumerable<ResponseError> errors)
        {
            Result = result;
            Errors = errors.ToList();
            TimeGenerated = DateTime.UtcNow;
        }

        public T? Result { get; }
        public List<ResponseError> Errors { get; } = new List<ResponseError>();
        public DateTime TimeGenerated { get; }

        public static Envelope<T> Ok(T? result = default)
        {
            return new Envelope<T>(result, new List<ResponseError>());
        }

        public static Envelope<T> Error(IEnumerable<ResponseError> errors)
        {
            return new Envelope<T>(default, errors);
        }
    }
}
