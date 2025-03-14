using backend.Communication.Contracts;
using FluentValidation;

namespace backend.Shared.Validators.Create
{
    public class CreateEmotionValidator : AbstractValidator<EmotionDto>
    {
        public CreateEmotionValidator()
        {

        }
    }
}
