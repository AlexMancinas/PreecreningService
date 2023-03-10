using FluentValidation;

namespace Application.Features.Phone.Commands.CreatePhoneCommand
{
    public class CreatePhoneCommandValidator : AbstractValidator<CreatePhoneCommand>
    {
        public CreatePhoneCommandValidator()
        {
            RuleFor(p => p.CandidateId)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");
            RuleFor(p => p.PhoneNumber)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .MaximumLength(10).WithMessage("{PropertyName} cannot be longer than {MaxLength} characters");
        }
    }
}
