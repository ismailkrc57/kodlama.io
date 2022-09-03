using FluentValidation;

namespace Application.Features.ProgramingLanguages.Commands.Create;

public class CreateProgramingLanguageValidator : AbstractValidator<CreateProgramingLanguageCommand>
{
    public CreateProgramingLanguageValidator()
    {
        RuleFor(pl => pl.Name).NotEmpty();
        RuleFor(pl => pl.Name).NotNull();
    }
}