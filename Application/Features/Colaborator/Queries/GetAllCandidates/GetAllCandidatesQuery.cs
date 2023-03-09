using Application.Interfaces;
using Application.Specifications;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Colaborator.Queries.GetAllCandidates
{
    public class GetAllCandidatesQuery : IRequest<List<Candidate>>
    { 
    }

    public class GetAllCandidatesQueryHandler : IRequestHandler<GetAllCandidatesQuery, List<Candidate>>
    {
        private readonly IRepositoryAsync<Candidate> _repositoryAsync;
        private readonly IMapper _mapper;
        public GetAllCandidatesQueryHandler(IRepositoryAsync<Candidate> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }


        public async Task<List<Candidate>> Handle(GetAllCandidatesQuery request, CancellationToken cancellationToken)
        {
          
            //var candidateWithEmails = _repositoryAsync.GetByIdAsync()
            var candidates = await _repositoryAsync.ListAsync();

            return candidates;

        }
    }


}
