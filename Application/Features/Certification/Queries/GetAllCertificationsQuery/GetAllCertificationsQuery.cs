using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Certification.Queries.GetAllCertificationsQuery
{
    public class GetAllCertificationsQuery : IRequest<List<Domain.Entities.Certification>>
    {
    }

    public class GetAllCertificationsQueryHandler : IRequestHandler<GetAllCertificationsQuery, List<Domain.Entities.Certification>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Certification> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllCertificationsQueryHandler(IRepositoryAsync<Domain.Entities.Certification> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public Task<List<Domain.Entities.Certification>> Handle(GetAllCertificationsQuery request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                throw new ArgumentNullException();
            }

            return HandleProcess(request, cancellationToken);
        }

        public async Task<List<Domain.Entities.Certification>> HandleProcess(GetAllCertificationsQuery request, CancellationToken cancellation)
        { 
            var certifications = await _repositoryAsync.ListAsync();
            return certifications;
        }
    }
}
