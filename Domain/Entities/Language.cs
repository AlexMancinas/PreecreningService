using Atos.Core.Abstractions;
using ATOS.Resource.Common.Abstraction;

namespace Domain.Entities
{
    public class Language : EntityBaseAuditable<Guid, Guid>
    {
        public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public string LanguageName { get; set; }
        public string LanguageLevel { get; set; }
        public Candidate Candidate { get; set; }
    }
}
