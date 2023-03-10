using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Email.Commands.LogicDeleteEmailCommand
{
    public class LogicDeleteEmailCommand : IRequest<Response<Domain.Entities.Email>>
    {
        public Guid Id { get; set; }
        public bool State { get; set; }
    }

    public class LogicDeleteEmailCommandHandler : IRequestHandler<LogicDeleteEmailCommand, Response<Domain.Entities.Email>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Email> _repositoryAsync;
        private readonly IMapper _mapper;

        public LogicDeleteEmailCommandHandler(IMapper mapper, IRepositoryAsync<Domain.Entities.Email> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }

        public Task<Response<Domain.Entities.Email>> Handle(LogicDeleteEmailCommand request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                throw new ArgumentNullException();
            }
            return HandleProcess(request, cancellationToken);
        }

        public async Task<Response<Domain.Entities.Email>> HandleProcess(LogicDeleteEmailCommand request, CancellationToken cancellationToken)
        {
            var email = await _repositoryAsync.GetByIdAsync(request.Id);

            if(email == null)
            {
                throw new Exception($"Email with id: {request.Id} doesn't exist");
            }
            else
            {
                email.State = request.State;

                await _repositoryAsync.UpdateAsync(email);

                return new Response<Domain.Entities.Email>(email);
            }
        }
    }
   
}
