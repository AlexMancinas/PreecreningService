using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Colaborator.Queries.GetAllCandidates
{
    public class GetAllCandidatesQuery: IRequest<List<Candidate>>
    {
        public class GetAllCandidatesQueryHandler : IRequestHandler<GetAllCandidatesQuery, List<Candidate>>
        {
            private readonly IRepositoryAsync<Candidate> _repositoryAsync;

            public GetAllCandidatesQueryHandler(IRepositoryAsync<Candidate> repositoryAsync)
            {
                _repositoryAsync = repositoryAsync;
            }

            private readonly IMapper _mapper;
            public async Task<List<Candidate>> Handle(GetAllCandidatesQuery request, CancellationToken cancellationToken)
            {
                var candidates = await _repositoryAsync.ListAsync();

                return candidates;

            }
        }
    }

}
