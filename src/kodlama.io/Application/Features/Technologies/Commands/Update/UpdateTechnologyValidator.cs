using FluentValidation;

namespace Application.Features.Technologies.Commands.Update;

public class UpdateTechnologyValidator : AbstractValidator<UpdateTechnologyCommand>
{
    public UpdateTechnologyValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50);
        RuleFor(t => t.ProgramingLanguageId)
            .NotNull();
    }
}