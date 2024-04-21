using Application.Features.EAV.Commands.CreateEAVEntity;
using FluentValidation;

namespace Core.Application.Features.EAV.Commands.CreateEAVEntity;
public class CreateEAVEntityCommandValidator : AbstractValidator<CreateEAVEntityCommand>
{
    public CreateEAVEntityCommandValidator()
    {
        RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.");
    }
}