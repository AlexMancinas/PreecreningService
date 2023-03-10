using Application.Interfaces;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Language.Commands.UpdateLanguageCommand
{
    public class UpdateLanguageCommand : IRequest<Response<Domain.Entities.Language>>
    {
        public Guid Id { get; set; }
        public string LanguageName { get; set; }
        public string LanguageLevel { get; set; }
    }

    public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, Response<Domain.Entities.Language>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Language> _repositoryAsync;

        public UpdateLanguageCommandHandler(IRepositoryAsync<Domain.Entities.Language> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public Task<Response<Domain.Entities.Language>> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                throw new ArgumentNullException();
            }
            return HandleProcess(request, cancellationToken);
        }

        public async Task<Response<Domain.Entities.Language>> HandleProcess(UpdateLanguageCommand request, CancellationToken cancellationToken)
        {
            var language = await _repositoryAsync.GetByIdAsync(request.Id);

            if(language == null)
            {
                throw new Exception($"Language with id: {request.Id} doesn't exist");
            }
            else
            {
                language.LanguageName = request.LanguageName;
                language.LanguageLevel = request.LanguageLevel;

                await _repositoryAsync.UpdateAsync(language);

                return new Response<Domain.Entities.Language>(language);
            }
        }
    }
}
