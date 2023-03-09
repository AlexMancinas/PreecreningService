using Atos.Core.Abstractions;

namespace Domain.Entities
{
    public class Skill : IEntityBase<Guid, Guid>
    {
        public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public string SkillName { get; set; }
        public string SkillDescription { get; set; }
        public bool State { get; set; }
        public Guid UserCreatorId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Candidate Candidate { get; set; }
    }
}
