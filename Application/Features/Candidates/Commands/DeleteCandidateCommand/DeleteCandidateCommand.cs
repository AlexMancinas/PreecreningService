using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Colaborator.Commands.DeleteCandidateCommand
{
    public class DeleteCandidateCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public bool State { get; set; }
    }

    public class DeleteCandidateCommandHandler : IRequestHandler<DeleteCandidateCommand, Response<Guid>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Candidate> _repositoryAsync;
        private readonly IMapper _mapper;

        public DeleteCandidateCommandHandler(IMapper mapper, IRepositoryAsync<Domain.Entities.Candidate> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }

        public Task<Response<Guid>> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                throw new ArgumentNullException();
            }
            return HandleProcess(request, cancellationToken);
        }

        public async Task<Response<Guid>> HandleProcess(DeleteCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidate = await _repositoryAsync.GetByIdAsync(request.Id);

            if(candidate == null)
            {
                throw new Exception($"Candidate with id: {request.Id} doesn't exist");
            }
            else
            {
                candidate.State = request.State;

                await _repositoryAsync.UpdateAsync(candidate);

                return new Response<Guid>(candidate.Id);
            }
        }
    }
}
