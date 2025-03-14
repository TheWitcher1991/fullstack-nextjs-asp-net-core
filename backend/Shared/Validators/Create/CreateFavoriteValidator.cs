using backend.Communication.Contracts;
using FluentValidation;

namespace backend.Shared.Validators.Create
{
    public class CreateFavoriteValidator : AbstractValidator<CreateFavoriteDto>
    {
        public CreateFavoriteValidator()
        {

        }
    }
}
