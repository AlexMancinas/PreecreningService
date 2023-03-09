using Ardalis.Specification;

namespace Application.Specifications
{
    public class EmailsByCandidateIdSpecification : Specification<Domain.Entities.Email>
    {
        public EmailsByCandidateIdSpecification(Guid CandidateId)
        {
            Query.Where(x => x.CandidateId == CandidateId);
        }
    }

}
