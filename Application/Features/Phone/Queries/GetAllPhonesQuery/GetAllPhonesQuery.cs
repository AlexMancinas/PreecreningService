using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.Phone.Queries.GetAllPhonesQuery
{
    public class GetAllPhonesQuery : IRequest<List<Domain.Entities.Phone>>
    {
    }

    public class GetAllPhonesQueryHandler : IRequestHandler<GetAllPhonesQuery, List<Domain.Entities.Phone>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Phone> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllPhonesQueryHandler(IRepositoryAsync<Domain.Entities.Phone> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<List<Domain.Entities.Phone>> Handle(GetAllPhonesQuery request, CancellationToken cancellationToken)
        {
            var phones = await _repositoryAsync.ListAsync();
            return phones;
        }
    }
}
