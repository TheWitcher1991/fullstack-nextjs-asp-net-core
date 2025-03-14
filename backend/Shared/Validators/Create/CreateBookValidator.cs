using backend.Communication.Contracts;
using FluentValidation;

namespace backend.Shared.Validators.Create
{
    public class CreateBookValidator : AbstractValidator<CreateBookDto>
    {
        public CreateBookValidator()
        {

        }
    }
}
