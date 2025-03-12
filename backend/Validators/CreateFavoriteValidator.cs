using backend.Contracts;
using FluentValidation;

namespace backend.Validators
{
    public class CreateFavoriteValidator : AbstractValidator<CreateFavoriteDto>
    {
        public CreateFavoriteValidator()
        {

        }
    }
}
