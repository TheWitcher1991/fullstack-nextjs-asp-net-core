using backend.Contracts;
using FluentValidation;

namespace backend.Validators.Create
{
    public class CreateEmotionValidator : AbstractValidator<EmotionDto>
    {
        public CreateEmotionValidator()
        {

        }
    }
}
