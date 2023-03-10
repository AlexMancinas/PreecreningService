using Application.Interfaces;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Skill.Commands.UpdateSkillCommand
{
    public class UpdateSkillCommand : IRequest<Response<Domain.Entities.Skill>>
    {
        public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public string SkillName { get; set; }
        public string SkillDescription { get; set; }
    }


    public class UpdateSkillCommandHandler : IRequestHandler<UpdateSkillCommand, Response<Domain.Entities.Skill>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Skill> _repositoryAsync;

        public UpdateSkillCommandHandler(IRepositoryAsync<Domain.Entities.Skill> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public Task<Response<Domain.Entities.Skill>> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                throw new ArgumentNullException();
            }
            return HandleProcess(request, cancellationToken);
        }

        public async Task<Response<Domain.Entities.Skill>> HandleProcess(UpdateSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = await _repositoryAsync.GetByIdAsync(request.Id);

            if(skill == null)
            {
                throw new Exception($"Skill with id: {request.Id} doesn't exist");
            }
            else
            {
                skill.CandidateId = request.CandidateId;
                skill.SkillName = request.SkillName;
                skill.SkillDescription = request.SkillDescription;

                await _repositoryAsync.UpdateAsync(skill);

                return new Response<Domain.Entities.Skill>(skill);
            }
        }
    }
}
