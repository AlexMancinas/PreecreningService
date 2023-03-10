using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.QuestionsAnswer.Queries.GetAllQuestionsAnswerQuery
{
    public class GetAllQuestionsAnswerQuery : IRequest<List<Domain.Entities.QuestionsAnswer>>
    {
    }

    public class GetAllQuestionsAnswerQueryHandler : IRequestHandler<GetAllQuestionsAnswerQuery, List<Domain.Entities.QuestionsAnswer>>
    {
        private readonly IRepositoryAsync<Domain.Entities.QuestionsAnswer> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllQuestionsAnswerQueryHandler(IRepositoryAsync<Domain.Entities.QuestionsAnswer> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<List<Domain.Entities.QuestionsAnswer>> Handle(GetAllQuestionsAnswerQuery request, CancellationToken cancellationToken)
        {
            var questionsAnswer = await _repositoryAsync.ListAsync();
            return questionsAnswer;
        }
    }
}
