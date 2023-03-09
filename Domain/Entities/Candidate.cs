using Atos.Core.Abstractions;

namespace Domain.Entities
{
    public class Candidate : IEntityBaseAuditable<Guid, Guid>
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Client { get; set; }
        public string Recruiter { get; set; }
        public string Location { get; set; }
        public string EducationLevel { get; set; } 
        public string CurrentPosition { get; set; }
        public float SalaryExpectations { get; set; }
        public float CurrentSalaryGross { get; set; }
        public string Experience { get; set; } 
        public string Notes { get; set; } 
        public string Img { get; set; }
        public string? CV { get; set; }
        public ICollection<Email> Emails { get; set; }
        public ICollection<Phone> Phones { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public ICollection<Certification> Certifications { get; set; }
        public ICollection<QuestionsAnswer> QuestionsAnswers { get; set; }
        public ICollection<Language> Languages { get; set; }
        public Guid UserModifierId { get ; set; }
        public DateTime DateLastModify { get; set; }
        public bool State { get; set; }
        public Guid UserCreatorId { get; set; }
        public DateTime CreatedDate { get; set; }

        public Candidate()
        {
            this.Phones = new List<Phone>();
            this.Emails = new List<Email>();
            this.Skills = new List<Skill>();
            this.Certifications = new List<Certification>();
            this.QuestionsAnswers = new List<QuestionsAnswer>();
            this.Languages = new List<Language>();

        }
    }
}
