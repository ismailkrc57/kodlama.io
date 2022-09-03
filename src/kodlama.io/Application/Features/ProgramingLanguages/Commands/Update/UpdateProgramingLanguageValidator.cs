using FluentValidation;

namespace Application.Features.ProgramingLanguages.Commands.Update;

public class UpdateProgramingLanguageValidator : AbstractValidator<UpdateProgramingLanguageCommand>
{
    public UpdateProgramingLanguageValidator()
    {
        RuleFor(pl => pl.Name).NotEmpty();
        RuleFor(pl => pl.Name).NotNull();
    }
}