using backend.Contracts;
using FluentValidation;

namespace backend.Validators
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryValidator()
        {

        }
    }
}
