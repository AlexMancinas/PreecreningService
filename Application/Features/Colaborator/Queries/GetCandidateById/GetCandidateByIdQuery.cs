
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Colaborator.Queries.GetCandidateById
{
    public class GetCandidateByIdQuery : IRequest<Response<Candidate>>
    {
        public Guid Id { get; set; }

        public class GetCandidateByIdQueryHandler : IRequestHandler<GetCandidateByIdQuery, Response<Candidate>>
        {
            private readonly IRepositoryAsync<Candidate> _repositoryAsync; 
            private readonly IMapper _mapper;

            public GetCandidateByIdQueryHandler(IMapper mapper, IRepositoryAsync<Candidate> repositoryAsync)
            {
                _mapper = mapper;
                _repositoryAsync = repositoryAsync;
            }

            public  Task<Response<Candidate>> Handle(GetCandidateByIdQuery request, CancellationToken cancellationToken)
            {

                if (request == null)
                {
                    throw new ArgumentNullException();
                }
                return HandleProcess(request, cancellationToken);
            }

            public async Task<Response<Candidate>> HandleProcess(GetCandidateByIdQuery request, CancellationToken cancellationToken)
            {
                var specification = new CandidateWithRelationedDataSpecification(request.Id);
                var candidate = await _repositoryAsync.GetBySpecAsync(specification);

                if(candidate == null)
                {
                    throw new KeyNotFoundException($"Register with id: {request.Id} not Found");
                }
                else
                {
                    return new Response<Candidate>(candidate);
                }

            }
        }
    }
}
