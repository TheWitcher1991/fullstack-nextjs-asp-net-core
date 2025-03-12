using backend.Contracts;
using FluentValidation;

namespace backend.Validators
{
    public class CreateEmotionValidator : AbstractValidator<EmotionDto>
    {
        public CreateEmotionValidator()
        {

        }
    }
}
