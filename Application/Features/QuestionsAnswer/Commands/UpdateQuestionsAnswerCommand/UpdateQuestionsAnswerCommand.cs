using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using MediatR;

namespace Application.Features.QuestionsAnswer.Commands.UpdateQuestionsAnswerCommand
{
    public class UpdateQuestionsAnswerCommand : IRequest<Response<Domain.Entities.QuestionsAnswer>>
    {
        public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public string Answer { get; set; }
    }

    public class UpdateQuestionsAnswerCommandHandler : IRequestHandler<UpdateQuestionsAnswerCommand, Response<Domain.Entities.QuestionsAnswer>>
    {
        private readonly IRepositoryAsync<Domain.Entities.QuestionsAnswer> _repositoryAsync;

        public UpdateQuestionsAnswerCommandHandler(IRepositoryAsync<Domain.Entities.QuestionsAnswer> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<Domain.Entities.QuestionsAnswer>> Handle(UpdateQuestionsAnswerCommand request, CancellationToken cancellationToken)
        {
            var questionsAnswer = await _repositoryAsync.GetByIdAsync(request.Id);
            if (questionsAnswer == null)
            {
                throw new ApiExceptions($"QuestionsAnswer Not Found.");
            }
            else
            {
                questionsAnswer.CandidateId = request.CandidateId;
                questionsAnswer.Answer = request.Answer;
                await _repositoryAsync.UpdateAsync(questionsAnswer);
                return new Response<Domain.Entities.QuestionsAnswer>(questionsAnswer);
            }
        }
    }
}
