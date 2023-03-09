using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.Skill.Commands.CreateSkillCommand
{
    public class CreateSkillCommand : IRequest<Domain.Entities.Skill>
    {
        //public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public string SkillName { get; set; }
        public string SkillDescription { get; set; }
        public bool State { get; set; }
        public Guid UserCreatorId { get; set; }
    }

    public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, Domain.Entities.Skill>
    {
        private readonly IRepositoryAsync<Domain.Entities.Skill> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateSkillCommandHandler(IRepositoryAsync<Domain.Entities.Skill> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public Task<Domain.Entities.Skill> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                throw new ArgumentNullException();
            }

            return HandleProcess(request, cancellationToken);
        }

        public async Task<Domain.Entities.Skill> HandleProcess(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = _mapper.Map<Domain.Entities.Skill>(request);
            var data = await _repositoryAsync.AddAsync(skill);
            
            return data;
        }
    }
}
