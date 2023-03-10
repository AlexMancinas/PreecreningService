using Atos.Core.Abstractions;
using ATOS.Resource.Common.Abstraction;

namespace Domain.Entities
{
    public class Certification : EntityBaseAuditable<Guid, Guid>
    {
        public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public string CertificactionName { get; set; }
        public string CertificationDescription { get; set; }
        public Candidate Candidate { get; set; }
    }
}
