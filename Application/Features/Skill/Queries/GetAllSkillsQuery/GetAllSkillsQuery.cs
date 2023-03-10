using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.Skill.Queries.GetAllSkillsQuery
{
    public class GetAllSkillsQuery : IRequest<List<Domain.Entities.Skill>>
    {
    }

    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<Domain.Entities.Skill>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Skill> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllSkillsQueryHandler(IRepositoryAsync<Domain.Entities.Skill> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<List<Domain.Entities.Skill>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = await _repositoryAsync.ListAsync();
            return skills;
        }
    }
}
