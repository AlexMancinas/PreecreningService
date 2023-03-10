using Atos.Core.Abstractions;
using ATOS.Resource.Common.Abstraction;

namespace Domain.Entities
{
    public class Phone : EntityBaseAuditable<Guid, Guid>
    {
        public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public string PhoneNumber { get; set; }
        public Candidate Candidate { get; set; }
 
    }
}
