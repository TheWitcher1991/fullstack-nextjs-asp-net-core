using backend.Contracts;
using FluentValidation;

namespace backend.Validators
{
    public class CreateBookValidator : AbstractValidator<CreateBookDto>
    {
        public CreateBookValidator()
        {
           
        }
    }
}
