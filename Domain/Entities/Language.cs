using Atos.Core.Abstractions;

namespace Domain.Entities
{
    public class Language : IEntityBase<Guid, Guid>
    {
        public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public string LanguageName { get; set; }
        public string LanguageLevel { get; set; }
        public bool State { get; set; }
        public Guid UserCreatorId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Candidate Candidate { get; set; }
    }
}
