using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Certification.Commands.CreateCertificationCommand
{
    public class CreateCertificationCommand : IRequest<Domain.Entities.Certification>
    {
        //public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public string CertificactionName { get; set; }
        public string CertificationDescription { get; set; }
        public bool State { get; set; }
        public Guid UserCreatorId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class CreateCertificationCommandHandler : IRequestHandler<CreateCertificationCommand, Domain.Entities.Certification>
    {
        private readonly IRepositoryAsync<Domain.Entities.Certification> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateCertificationCommandHandler(IRepositoryAsync<Domain.Entities.Certification> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }


        public Task<Domain.Entities.Certification> Handle(CreateCertificationCommand request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                throw new ArgumentNullException();
            }

            return HandleProcess(request, cancellationToken);
        }

        public async Task<Domain.Entities.Certification> HandleProcess(CreateCertificationCommand request, CancellationToken cancellationToken)
        {
            var certification = _mapper.Map<Domain.Entities.Certification>(request);
            var data = await _repositoryAsync.AddAsync(certification);
            
            return data;
        }
    }
}
