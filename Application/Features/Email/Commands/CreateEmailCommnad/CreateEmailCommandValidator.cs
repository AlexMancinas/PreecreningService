using FluentValidation;

namespace Application.Features.Email.Commands.CreateEmailCommnad
{
    public class CreateEmailCommandValidator : AbstractValidator<CreateEmailCommand>
    {
        public CreateEmailCommandValidator()
        {
            RuleFor(e => e.CandidateId)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");
            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .MaximumLength(120).WithMessage("{PropertyName} cannot be longer than {MaxLength} characters");
        }
    }
}
