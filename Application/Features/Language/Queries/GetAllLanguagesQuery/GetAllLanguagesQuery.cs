using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Language.Queries.GetAllCandidatesQuery
{
    public class GetAllLanguagesQuery : IRequest<List<Domain.Entities.Language>>
    {
    }

    public class GetAllCandidatesQueryHandler : IRequestHandler<GetAllLanguagesQuery, List<Domain.Entities.Language>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Language> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllCandidatesQueryHandler(IRepositoryAsync<Domain.Entities.Language> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<List<Domain.Entities.Language>> Handle(GetAllLanguagesQuery request, CancellationToken cancellationToken)
        {
            var Languges = await _repositoryAsync.ListAsync();
            return Languges;
        }
    }   
}
