using Application.Interfaces;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Skill.Commands.LogicDeleteSkillCommand
{
    public class LogicDeleteSkillCommand : IRequest<Response<Domain.Entities.Skill>>
    {
        public Guid Id { get; set; }
        public bool State { get; set; }
    }

    public class LogicDeleteSkillCommandHandler : IRequestHandler<LogicDeleteSkillCommand, Response<Domain.Entities.Skill>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Skill> _repositoryAsync;

        public LogicDeleteSkillCommandHandler(IRepositoryAsync<Domain.Entities.Skill> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public Task<Response<Domain.Entities.Skill>> Handle(LogicDeleteSkillCommand request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                throw new ArgumentNullException();
            }
            return HandleProcess(request, cancellationToken);
        }

        public async Task<Response<Domain.Entities.Skill>> HandleProcess(LogicDeleteSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = await _repositoryAsync.GetByIdAsync(request.Id);

            if(skill == null)
            {
                throw new Exception($"Skill with id: {request.Id} doesn't exist");
            }
            else
            {
                skill.State = request.State;

                await _repositoryAsync.UpdateAsync(skill);

                return new Response<Domain.Entities.Skill>(skill);
            }
        }
    }
}
