using FluentValidation;

namespace Application.Features.Skill.Commands.CreateSkillCommand
{
    public class CreateSkillCommandValidator : AbstractValidator<CreateSkillCommand>
    {
        public CreateSkillCommandValidator()
        {
            RuleFor(s => s.CandidateId)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");
            RuleFor(s => s.SkillName)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .MaximumLength(120).WithMessage("{PropertyName} cannot be longer than {MaxLength} characters");
            RuleFor(s => s.SkillDescription)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .MaximumLength(120).WithMessage("{PropertyName} cannot be longer than {MaxLength} characters");
        }
    }
}
