using backend.Communication.Contracts;
using FluentValidation;

namespace backend.Shared.Validators.Create
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryValidator()
        {
            RuleFor(t => t.Title)
                .NotEmpty()
                .MaximumLength(Config.MAX_TITLE_LENGTH);

            RuleFor(t => t.Topic).NotEmpty();
        }
    }
}
