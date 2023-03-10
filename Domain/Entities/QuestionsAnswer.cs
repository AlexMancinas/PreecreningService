using Atos.Core.Abstractions;
using ATOS.Resource.Common.Abstraction;

namespace Domain.Entities
{
    public class QuestionsAnswer : EntityBaseAuditable<Guid, Guid>
    {
        public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public string Answer { get; set; }
        public Candidate Candidate { get; set; }
    }
}
