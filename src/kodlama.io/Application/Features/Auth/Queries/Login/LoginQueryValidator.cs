using FluentValidation;

namespace Application.Features.Auth.Queries.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(x => x.UserForLoginDto.Email).NotEmpty().NotNull();
        RuleFor(x => x.UserForLoginDto.Password).NotEmpty().NotNull();
    }
}