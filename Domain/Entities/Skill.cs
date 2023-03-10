using Atos.Core.Abstractions;
using ATOS.Resource.Common.Abstraction;

namespace Domain.Entities
{
    public class Skill : EntityBaseAuditable<Guid, Guid>
    {
        public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public string SkillName { get; set; }
        public string SkillDescription { get; set; }
        public Candidate Candidate { get; set; }
    }
}
