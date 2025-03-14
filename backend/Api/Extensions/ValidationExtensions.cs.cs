using backend.Api.Extensions;
using backend.Shared.Core;
using FluentValidation.Results;

namespace backend.Api.Extensions
{
    public static class ValidationExtensions
    {
        public static ErrorList ToList(this ValidationResult validationResult)
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
