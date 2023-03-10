using Application.Interfaces;
using Application.Wrappers;
using MediatR;

namespace Application.Features.QuestionsAnswer.Commands.LogicDeleteQuestionsAnswerCommand
{
    public class LogicDeleteQuestionsAnswerCommand : IRequest<Response<Domain.Entities.QuestionsAnswer>>
    {
        public Guid Id { get; set; }
        public bool State { get; set; }
    }

    public class LogicDeleteQuestionsAnswerCommandHandler : IRequestHandler<LogicDeleteQuestionsAnswerCommand, Response<Domain.Entities.QuestionsAnswer>>
    {
        private readonly IRepositoryAsync<Domain.Entities.QuestionsAnswer> _repositoryAsync;

        public LogicDeleteQuestionsAnswerCommandHandler(IRepositoryAsync<Domain.Entities.QuestionsAnswer> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public Task<Response<Domain.Entities.QuestionsAnswer>> Handle(LogicDeleteQuestionsAnswerCommand request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                throw new ArgumentNullException();
            }
            return HandleProcess(request, cancellationToken);
        }

        public async Task<Response<Domain.Entities.QuestionsAnswer>> HandleProcess(LogicDeleteQuestionsAnswerCommand request, CancellationToken cancellationToken)
        {
            var questionsAnswer = await _repositoryAsync.GetByIdAsync(request.Id);

            if(questionsAnswer == null)
            {
                throw new Exception($"QuestionsAnswer with id: {request.Id} doesn't exist");
            }
            else
            {
                questionsAnswer.State = request.State;

                await _repositoryAsync.UpdateAsync(questionsAnswer);

                return new Response<Domain.Entities.QuestionsAnswer>(questionsAnswer);
            }
        }
    }
}
