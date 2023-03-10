using Application.Interfaces;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Language.Commands.LogicDeleteLanguageCommand
{
    public class LogicDeleteLanguageCommand : IRequest<Response<Domain.Entities.Language>>
    {
        public Guid Id { get; set; }
        public bool State { get; set; }
    }

    public class LogicDeleteLanguageCommandHandler : IRequestHandler<LogicDeleteLanguageCommand, Response<Domain.Entities.Language>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Language> _repositoryAsync;

        public LogicDeleteLanguageCommandHandler(IRepositoryAsync<Domain.Entities.Language> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public Task<Response<Domain.Entities.Language>> Handle(LogicDeleteLanguageCommand request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                throw new ArgumentNullException();
            }
            return HandleProcess(request, cancellationToken);
        }

        public async Task<Response<Domain.Entities.Language>> HandleProcess(LogicDeleteLanguageCommand request, CancellationToken cancellationToken)
        {
            var language = await _repositoryAsync.GetByIdAsync(request.Id);

            if(language == null)
            {
                throw new Exception($"Language with id: {request.Id} doesn't exist");
            }
            else
            {
                language.State = request.State;

                await _repositoryAsync.UpdateAsync(language);

                return new Response<Domain.Entities.Language>(language);
            }
        }
    }
}
