using FluentValidation;

namespace Application.Features.Certification.Commands.UpdateCertificationCommand
{
    public class UpdateCertificationCommandValidator : AbstractValidator<UpdateCertificationCommand>
    {
        public UpdateCertificationCommandValidator()
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
