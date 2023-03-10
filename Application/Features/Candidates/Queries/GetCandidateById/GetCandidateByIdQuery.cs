
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Colaborator.Queries.GetCandidateById
{
    public class GetCandidateByIdQuery : IRequest<Response<Domain.Entities.Candidate>>
    {
        public Guid Id { get; set; }

        public class GetCandidateByIdQueryHandler : IRequestHandler<GetCandidateByIdQuery, Response<Domain.Entities.Candidate>>
        {
            private readonly IRepositoryAsync<Domain.Entities.Candidate> _repositoryAsync; 
            private readonly IMapper _mapper;

            public GetCandidateByIdQueryHandler(IMapper mapper, IRepositoryAsync<Domain.Entities.Candidate> repositoryAsync)
            {
                _mapper = mapper;
                _repositoryAsync = repositoryAsync;
            }

            public  Task<Response<Domain.Entities.Candidate>> Handle(GetCandidateByIdQuery request, CancellationToken cancellationToken)
            {

                if (request == null)
                {
                    throw new ArgumentNullException();
                }
                return HandleProcess(request, cancellationToken);
            }

            public async Task<Response<Domain.Entities.Candidate>> HandleProcess(GetCandidateByIdQuery request, CancellationToken cancellationToken)
            {
                var specification = new CandidateWithRelationedDataSpecification(request.Id);
                var candidate = await _repositoryAsync.GetBySpecAsync(specification);

                if(candidate == null)
                {
                    throw new KeyNotFoundException($"Register with id: {request.Id} not Found");
                }
                else
                {
                    return new Response<Domain.Entities.Candidate>(candidate);
                }

            }
        }
    }
}
