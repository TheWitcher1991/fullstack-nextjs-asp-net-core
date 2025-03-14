using backend.Contracts;
using FluentValidation;

namespace backend.Validators.Create
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator()
        {

        }
    }
}
