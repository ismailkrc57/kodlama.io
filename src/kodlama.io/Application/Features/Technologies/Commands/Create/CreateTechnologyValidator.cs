using FluentValidation;

namespace Application.Features.Technologies.Commands.Create;

public class CreateTechnologyValidator : AbstractValidator<CreateTechnologyCommand>
{
    public CreateTechnologyValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        RuleFor(t => t.ProgramingLanguageId)
            .NotNull()
            .WithMessage("{PropertyName} is required.");
    }
}