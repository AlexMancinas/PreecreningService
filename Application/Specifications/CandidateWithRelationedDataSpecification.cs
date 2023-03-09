using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications
{
    public class CandidateWithRelationedDataSpecification : Specification<Candidate>
    {
        public CandidateWithRelationedDataSpecification(Guid CandidateId)
        {
            Query.Where(c => c.Id == CandidateId);
            Query.Include(c => c.Emails);
            Query.Include(c => c.Certifications);
            Query.Include(c => c.Languages);
            Query.Include(c => c.Phones);
            Query.Include(c => c.QuestionsAnswers);
            Query.Include(c => c.Skills);
        }
    }
}
