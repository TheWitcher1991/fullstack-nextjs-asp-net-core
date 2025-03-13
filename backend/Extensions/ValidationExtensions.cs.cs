using backend.Shared;
using FluentValidation.Results;

namespace backend.Extensions
{
    public static class ValidationExtensions
    {
        public static List<Error> ToList(this ValidationResult validationResult)
        {
            var validationErrors = validationResult.Errors;

            var errors = from validationError in validationErrors
                         let errorMessage = validationError.ErrorMessage
                         let error = Error.Deserialize(errorMessage)
                         select Error.Validation(error.Code, error.Message);

            return errors.ToList();
        }
    }
}
