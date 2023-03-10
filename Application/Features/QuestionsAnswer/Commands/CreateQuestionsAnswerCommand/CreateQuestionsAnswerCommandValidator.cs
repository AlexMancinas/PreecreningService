using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.QuestionsAnswer.Commands.CreateQuestionsAnswerCommand
{
    public class CreateQuestionsAnswerCommandValidator : AbstractValidator<CreateQuestionsAnswerCommand>
    {
        public CreateQuestionsAnswerCommandValidator()
        {
            RuleFor(q => q.CandidateId)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");
            RuleFor(q => q.Answer)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .MaximumLength(120).WithMessage("{PropertyName} cannot be longer than {MaxLength} characters");
        }
    }
}
