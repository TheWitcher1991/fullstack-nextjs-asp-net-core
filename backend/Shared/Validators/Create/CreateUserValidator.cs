using backend.Communication.Contracts;
using FluentValidation;

namespace backend.Shared.Validators.Create
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator()
        {

        }
    }
}
