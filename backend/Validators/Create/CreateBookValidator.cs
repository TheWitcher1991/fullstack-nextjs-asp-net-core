using backend.Contracts;
using FluentValidation;

namespace backend.Validators.Create
{
    public class CreateBookValidator : AbstractValidator<CreateBookDto>
    {
        public CreateBookValidator()
        {

        }
    }
}
