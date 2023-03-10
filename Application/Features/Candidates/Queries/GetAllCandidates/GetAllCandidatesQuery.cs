using Application.Interfaces;
using Application.Specifications;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Colaborator.Queries.GetAllCandidates
{
    public class GetAllCandidatesQuery : IRequest<List<Domain.Entities.Candidate>>
    { 
    }

    public class GetAllCandidatesQueryHandler : IRequestHandler<GetAllCandidatesQuery, List<Domain.Entities.Candidate>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Candidate> _repositoryAsync;
        private readonly IMapper _mapper;
        public GetAllCandidatesQueryHandler(IRepositoryAsync<Domain.Entities.Candidate> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }


        public async Task<List<Domain.Entities.Candidate>> Handle(GetAllCandidatesQuery request, CancellationToken cancellationToken)
        {
          
            //var candidateWithEmails = _repositoryAsync.GetByIdAsync()
            var candidates = await _repositoryAsync.ListAsync();

            return candidates;

        }
    }


}
