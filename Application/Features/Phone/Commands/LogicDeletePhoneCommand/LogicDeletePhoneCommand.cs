using Application.Features.Certification.Commands.LogicDeleteCertificationCommand;
using Application.Interfaces;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Phone.Commands.LogicDeletePhoneCommand
{
    public class LogicDeletePhoneCommand : IRequest<Response<Domain.Entities.Phone>>
    {
        public Guid Id { get; set; }
        public bool State { get; set; }
    }

    
    public class LogicDeletePhoneCommandHandler : IRequestHandler<LogicDeletePhoneCommand, Response<Domain.Entities.Phone>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Phone> _repositoryAsync;

        public LogicDeletePhoneCommandHandler(IRepositoryAsync<Domain.Entities.Phone> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public Task<Response<Domain.Entities.Phone>> Handle(LogicDeletePhoneCommand request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                throw new ArgumentNullException();
            }
            return HandleProcess(request, cancellationToken);
        }

        public async Task<Response<Domain.Entities.Phone>> HandleProcess(LogicDeletePhoneCommand request, CancellationToken cancellationToken)
        {
            var phone = await _repositoryAsync.GetByIdAsync(request.Id);

            if(phone == null)
            {
                throw new Exception($"Phone with id: {request.Id} doesn't exist");
            }
            else
            {
                phone.State = request.State;

                await _repositoryAsync.UpdateAsync(phone);

                return new Response<Domain.Entities.Phone>(phone);
            }
        }
    }
}
