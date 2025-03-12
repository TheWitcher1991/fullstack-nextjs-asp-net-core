using backend.Contracts;
using FluentValidation;

namespace backend.Validators
{
    public class CreateTopicValidator : AbstractValidator<CreateTopicDto>
    {
        public CreateTopicValidator() {
            RuleFor(t => t.Title)
                .NotEmpty()
                .MaximumLength(Config.MAX_TITLE_LENGTH);
        }

    }
}
