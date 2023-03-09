using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.QuestionsAnswer.Commands.CreateQuestionsAnswerCommand
{
    public class CreateQuestionsAnswerCommand : IRequest<Domain.Entities.QuestionsAnswer>
    {
        //public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public string Answer { get; set; }
        public bool State { get; set; }
        public Guid UserCreatorId { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class CreateQuestionsAnswerCommandHandler : IRequestHandler<CreateQuestionsAnswerCommand, Domain.Entities.QuestionsAnswer>
    {
        private readonly IRepositoryAsync<Domain.Entities.QuestionsAnswer> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateQuestionsAnswerCommandHandler(IRepositoryAsync<Domain.Entities.QuestionsAnswer> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public Task<Domain.Entities.QuestionsAnswer> Handle(CreateQuestionsAnswerCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException();
            }

            return HandleProcess(request, cancellationToken);
        }

        public async Task<Domain.Entities.QuestionsAnswer> HandleProcess(CreateQuestionsAnswerCommand request, CancellationToken cancellationToken)
        {
            var questionsAnswer = _mapper.Map<Domain.Entities.QuestionsAnswer>(request);
            var data = await _repositoryAsync.AddAsync(questionsAnswer);

            return data;
        }
    }
}
