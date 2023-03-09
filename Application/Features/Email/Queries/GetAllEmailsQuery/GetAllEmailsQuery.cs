using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.Email.Queries.GetAllEmailsQuery
{
    public class GetAllEmailsQuery : IRequest<List<Domain.Entities.Email>>
    {
    }

    public class GetAllEmailsQueryHandler : IRequestHandler<GetAllEmailsQuery, List<Domain.Entities.Email>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Email> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllEmailsQueryHandler(IRepositoryAsync<Domain.Entities.Email> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<List<Domain.Entities.Email>> Handle(GetAllEmailsQuery request, CancellationToken cancellationToken)
        {
            var emails = await _repositoryAsync.ListAsync();
            return emails;
        }
    }
}
