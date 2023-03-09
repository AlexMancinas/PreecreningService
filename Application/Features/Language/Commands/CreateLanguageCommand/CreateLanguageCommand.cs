using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Language.Commands.CreateLanguageCommand
{
    public class CreateLanguageCommand : IRequest<Domain.Entities.Language>
    {
        //public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public string LanguageName { get; set; }
        public string LanguageLevel { get; set; }
        public bool State { get; set; }
        public Guid UserCreatorId { get; set; }
    }

    public class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommand, Domain.Entities.Language>
    {
        private readonly IRepositoryAsync<Domain.Entities.Language> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateLanguageCommandHandler(IMapper mapper, IRepositoryAsync<Domain.Entities.Language> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }

        public Task<Domain.Entities.Language> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException();
            }
            return HandleProcess(request, cancellationToken);
        }

        public async Task<Domain.Entities.Language> HandleProcess(CreateLanguageCommand request, CancellationToken cancellationToken)
        {
            var language = _mapper.Map<Domain.Entities.Language>(request);
            var data = await _repositoryAsync.AddAsync(language);
            return data;
        }
    }
}
