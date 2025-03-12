/*
using FluentValidation;

namespace backend.Validators
{
    public class Error
    {
        public string Message { get; }

        public Error(string message)
        {
            Message = message;
        }
    }

    public static class CustomValidators
    {
        public static IRuleBuilderOptionsConditions<T, TElement> MustBeValueObject<T, TElement, TValueObject>(
            this IRuleBuilder<T, TElement> ruleBulder,
            Func<TElement, Result<TValueObject, Error>> factorMethod)
        {
            return ruleBulder.Custom((value, context) =>
            {
                Result<TValueObject, Error> result = factorMethod(value);

                if (result.IsSuccess)
                {
                    return;
                }

                context.AddFailure(result.Error.Message);
            });
        }
    }
}
*/

