using FluentValidation;

namespace Application.Features.GithubAccounts.Commands.Create;

public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>

{
    public CreateAccountCommandValidator()
    {
        RuleFor(a => a.Url).NotEmpty().NotNull();
        RuleFor(a => a.UserId).NotEmpty().NotNull();
        RuleFor(a => a.Username).NotEmpty().NotNull();
    }
}