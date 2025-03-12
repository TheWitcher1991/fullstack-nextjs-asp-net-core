using backend.Contracts;
using FluentValidation;

namespace backend.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator()
        {

        }
    }
}
