using Atos.Core.Abstractions;
using ATOS.Resource.Common.Abstraction;

namespace Domain.Entities
{
    public class Email : EntityBaseAuditable<Guid, Guid>
    {
        public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        static string EmailAddress { get; set; }
        public Candidate Candidate { get; set; }
    }
}
