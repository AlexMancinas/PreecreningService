using FluentValidation;

namespace Application.Features.Certification.Commands.CreateCertificationCommand
{
    public class CreateCertificationCommandValidator : AbstractValidator<CreateCertificationCommand>
    {
        public CreateCertificationCommandValidator()
        {
            RuleFor(c => c.CandidateId)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");
            RuleFor(c => c.CertificactionName)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .MaximumLength(120).WithMessage("{PropertyName} cannot be longer than {MaxLength} characters");
            RuleFor(c => c.CertificationDescription)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .MaximumLength(120).WithMessage("{PropertyName} cannot be longer than {MaxLength} characters");
        }
    }
}
