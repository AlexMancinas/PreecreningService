using Application.Features.Colaborator.Commands.CreateCandidateCommand;
using FluentValidation;

namespace Application.Features.Candidates.Commands.CreateCandidatesCommand
{
    public class CreateCandidateCommandValidator : AbstractValidator<CreateCandidateCommand>
    {
        public CreateCandidateCommandValidator()
        {
            RuleFor(c => c.FullName)
                .NotEmpty().WithMessage("{FullName} is required.");
            RuleFor(p => p.Recruiter)
             .NotEmpty().WithMessage("{PropertyName} cannot be empty")
             .MaximumLength(120).WithMessage("{PropertyName} cannot be longer than {MaxLength} characters");

            RuleFor(p => p.Location)
              .NotEmpty().WithMessage("{PropertyName} cannot be empty")
              .MaximumLength(80).WithMessage("{PropertyName} cannot be longer than {MaxLength} characters");
            RuleFor(p => p.EducationLevel)
              .NotEmpty().WithMessage("{PropertyName} cannot be empty")
              .MaximumLength(30).WithMessage("{PropertyName} cannot be longer than {MaxLength} characters");
            RuleFor(p => p.CurrentPosition)
              .NotEmpty().WithMessage("{PropertyName} cannot be empty")
              .MaximumLength(80).WithMessage("{PropertyName} cannot be longer than {MaxLength} characters");
            RuleFor(p => p.SalaryExpectations)
              .NotEmpty().WithMessage("{PropertyName} cannot be empty")
              .LessThan(9999999).WithMessage("{PropertyName} cannot be greater than a number with 7 digits");
            RuleFor(p => p.CurrentSalaryGross)
              .NotEmpty().WithMessage("{PropertyName} cannot be empty")
              .LessThan(9999999).WithMessage("{PropertyName} cannot be greater than a number with 7 digits");
            RuleFor(p => p.Experience)
              .NotEmpty().WithMessage("{PropertyName} cannot be empty")
              .MaximumLength(150).WithMessage("{PropertyName} cannot be longer than {MaxLength} characters");
            RuleFor(p => p.Notes)
              .NotEmpty().WithMessage("{PropertyName} cannot be empty")
              .MaximumLength(150).WithMessage("{PropertyName} cannot be longer than {MaxLength} characters");
        }
    }
}
