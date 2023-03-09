using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Colaborator.Commands.CreateCandidateCommand
{
    public class CreateCandidateCommand : IRequest<Response<Guid>>
    {
        public string FullName { get; set; }
        public string Client { get; set; }
        public string Recruiter { get; set; }
        public string Location { get; set; }
        public string EducationLevel { get; set; }
        public string CurrentPosition { get; set; }
        public float SalaryExpectations { get; set; }
        public float CurrentSalaryGross { get; set; }
        public string Experience { get; set; }
        public string Notes { get; set; }
        public string Img { get; set; }
        public string CV { get; set; }
        public Guid UserModifierId { get; set; }
        public DateTime DateLastModify { get; set; }
        public bool State { get; set; }
        public Guid UserCreatorId { get; set; }
    }
    
    public class Handler : IRequestHandler<CreateCandidateCommand, Response<Guid>>
    {
        private readonly IRepositoryAsync<Candidate> _repositoryAsync;
        private readonly IMapper _mapper;

        public Handler(IMapper mapper, IRepositoryAsync<Candidate> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }

        public Task<Response<Guid>> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException();
            }

            return HandleProcess(request, cancellationToken);
        }

        public async Task<Response<Guid>> HandleProcess(CreateCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidate = _mapper.Map<Candidate>(request);
            var data = await _repositoryAsync.AddAsync(candidate);

            return new Response<Guid>(data.Id);
        }
    }



}

