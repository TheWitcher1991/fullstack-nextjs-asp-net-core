using backend.Contracts;
using FluentValidation;

namespace backend.Validators.Create
{
    public class CreateFavoriteValidator : AbstractValidator<CreateFavoriteDto>
    {
        public CreateFavoriteValidator()
        {

        }
    }
}
