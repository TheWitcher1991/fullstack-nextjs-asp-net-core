namespace backend.Shared.Core
{
    public class Result
    {
        public Result(bool isSuccess, IEnumerable<Error> errors)
        {
            if (isSuccess && errors.Any(x => x != Error.None))
                throw new InvalidOperationException();

            if (!isSuccess && errors.Any(x => x == Error.None))
                throw new InvalidOperationException();

            IsSuccess = isSuccess;
            Errors = errors.ToList();
        }

        public ErrorList Errors { get; set; }
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;

        public static Result Success()
        {
            return new(true, new List<Error> { Error.None });
        }

        public static Result Failure(Error error)
        {
            return new(false, new List<Error> { error });
        }

        public static implicit operator Result(Error error)
        {
            return new(false, new List<Error> { error });
        }

        public static implicit operator Result(ErrorList errors)
        {
            return new(false, errors);
        }

        public override string ToString()
        {
            return string.Join("\n", Errors);
        }
    }

    public class Result<TValue> : Result
    {
        public Result(TValue value, bool isSuccess, IEnumerable<Error> errors)
            : base(isSuccess, errors)
        {
            _value = value;
        }

        private readonly TValue _value;

        public TValue Value => IsSuccess
            ? _value
            : throw new InvalidOperationException("The value of a failure result cannot be accessed");

        public static Result<TValue> Success(TValue value)
        {
            return new(value, true, new List<Error> { Error.None });
        }

        public new static Result<TValue> Failure(Error error)
        {
            return new(default!, false, new List<Error> { error });
        }

        public static implicit operator Result<TValue>(TValue value)
        {
            return new(value, true, new List<Error> { Error.None });
        }

        public static implicit operator Result<TValue>(Error error)
        {
            return new(default!, false, new List<Error> { error });
        }

        public static implicit operator Result<TValue>(ErrorList errors)
        {
            return new(default!, false, errors);
        }
    }
}
