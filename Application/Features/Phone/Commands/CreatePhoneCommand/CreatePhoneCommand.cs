using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.Phone.Commands.CreatePhoneCommand
{
    public class CreatePhoneCommand : IRequest<Domain.Entities.Phone>
    {
        //public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public string PhoneNumber { get; set; }
        public bool State { get; set; }
        public Guid UserCreatorId { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class CreatePhoneCommandHandler : IRequestHandler<CreatePhoneCommand, Domain.Entities.Phone>
    {
        private readonly IRepositoryAsync<Domain.Entities.Phone> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreatePhoneCommandHandler(IRepositoryAsync<Domain.Entities.Phone> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public Task<Domain.Entities.Phone> Handle(CreatePhoneCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException();
            }

            return HandleProcess(request, cancellationToken);
        }

        public async Task<Domain.Entities.Phone> HandleProcess(CreatePhoneCommand request, CancellationToken cancellationToken)
        {
            var phone = _mapper.Map<Domain.Entities.Phone>(request);
            var data = await _repositoryAsync.AddAsync(phone);

            return data;
        }
    }
}
