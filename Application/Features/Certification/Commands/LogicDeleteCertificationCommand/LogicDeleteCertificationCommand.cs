using Application.Interfaces;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Certification.Commands.LogicDeleteCertificationCommand
{
    public class LogicDeleteCertificationCommand : IRequest<Response<Domain.Entities.Certification>>
    {
        public Guid Id { get; set; }
        public bool State { get; set; }
    }

    public class LogicDeleteCertificationCommandHandler : IRequestHandler<LogicDeleteCertificationCommand, Response<Domain.Entities.Certification>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Certification> _repositoryAsync;

        public LogicDeleteCertificationCommandHandler(IRepositoryAsync<Domain.Entities.Certification> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public Task<Response<Domain.Entities.Certification>> Handle(LogicDeleteCertificationCommand request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                throw new ArgumentNullException();
            }
            return HandleProcess(request, cancellationToken);
        }

        public async Task<Response<Domain.Entities.Certification>> HandleProcess(LogicDeleteCertificationCommand request, CancellationToken cancellationToken)
        {
            var certification = await _repositoryAsync.GetByIdAsync(request.Id);

            if(certification == null)
            {
                throw new Exception($"Certification with id: {request.Id} doesn't exist");
            }
            else
            {
                certification.State = request.State;

                await _repositoryAsync.UpdateAsync(certification);

                return new Response<Domain.Entities.Certification>(certification);
            }
        }
    }
}
