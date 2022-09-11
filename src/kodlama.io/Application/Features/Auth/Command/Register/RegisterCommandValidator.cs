using Core.Security.Dtos;
using FluentValidation;

namespace Application.Features.Auth.Command.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.UserForRegisterDto.Email).NotEmpty().EmailAddress().NotNull();
        RuleFor(x => x.UserForRegisterDto.Password).NotEmpty().MinimumLength(6).NotNull();
        RuleFor(x => x.UserForRegisterDto.FirstName).NotEmpty().NotNull();
        RuleFor(x => x.UserForRegisterDto.LastName).NotEmpty().NotNull();
    }
}