using FluentValidation;

namespace Application.Features.Users.Command.Update;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>

{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.FirstName).NotEmpty().NotNull();
        RuleFor(x => x.LastName).NotEmpty().NotNull();
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
    }
}