using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Certification.Commands.UpdateCertificationCommand
{
    public class UpdateCertificationCommand : IRequest<Response<Domain.Entities.Certification>>
    {
        public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public string CertificactionName { get; set; }
        public string CertificationDescription { get; set; }

    }

    public class UpdateCertificationCommandHandler : IRequestHandler<UpdateCertificationCommand, Response<Domain.Entities.Certification>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Certification> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateCertificationCommandHandler(IRepositoryAsync<Domain.Entities.Certification> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<Domain.Entities.Certification>> Handle(UpdateCertificationCommand request, CancellationToken cancellationToken)
        {
            var certification = await _repositoryAsync.GetByIdAsync(request.Id);
            if (certification == null)
            {
                throw new ApiExceptions($"Certification Not Found.");
            }
            else
            {
                certification.CandidateId = request.CandidateId;
                certification.CertificactionName = request.CertificactionName;
                certification.CertificationDescription = request.CertificationDescription;
                await _repositoryAsync.UpdateAsync(certification);
                return new Response<Domain.Entities.Certification>(certification);
            }
        }
    }   
}
