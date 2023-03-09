using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Email.Commands.CreateEmailCommnad
{
    public class CreateEmailCommand : IRequest<Response<Guid>>
    {
        //public Guid Id { get; set; }
        public string Email { get; set; }
        public Guid CandidateId { get; set; }
        public Guid UserModifierId { get; set; }
        public DateTime DateLastModify { get; set; }
        public bool State { get; set; }
        public Guid UserCreatorId { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class Handler : IRequestHandler<CreateEmailCommand, Response<Guid>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Email> _repositoryAsync;
        private readonly IMapper _mapper;

        public Handler(IMapper mapper, IRepositoryAsync<Domain.Entities.Email> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }

        public Task<Response<Guid>> Handle(CreateEmailCommand request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                throw new ArgumentNullException();
            }

            return HandleProcess(request, cancellationToken);
        }

        public async Task<Response<Guid>> HandleProcess(CreateEmailCommand request, CancellationToken cancellation)
        {
            var Email = _mapper.Map<Domain.Entities.Email>(request);
            var data = await _repositoryAsync.AddAsync(Email);

            return new Response<Guid>(data.Id);
        }
    }
}
