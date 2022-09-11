using FluentValidation;

namespace Application.Features.GithubAccounts.Commands.Create;

public class UpdateAccountCommandValidator : AbstractValidator<CreateAccountCommand>

{
    public UpdateAccountCommandValidator()
    {
        RuleFor(a => a.Url).NotEmpty().NotNull();
        RuleFor(a => a.Username).NotEmpty().NotNull();
    }
}