using Application.Interfaces;
using Application.Specifications;
using AutoMapper;
using MediatR;

namespace Application.Features.Email.Queries.GetEmailsByCanidateIdQyery
{
    public class GetEmailsByCandidateIdQuery : IRequest<List<Domain.Entities.Email>>
    {
        public Guid CandidateId { get; set; }
    }

    public class GetEmailsByCandidateIdQueryHandler : IRequestHandler<GetEmailsByCandidateIdQuery, List<Domain.Entities.Email>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Email> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetEmailsByCandidateIdQueryHandler(IMapper mapper, IRepositoryAsync<Domain.Entities.Email> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }

        public Guid CandidateId { get; set; }

        public async Task<List<Domain.Entities.Email>> Handle(GetEmailsByCandidateIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new EmailsByCandidateIdSpecification(request.CandidateId);

            var emails = await _repositoryAsync.ListAsync(specification);
            return emails;


        }
    }
}
