using Atos.Core.Abstractions;

namespace Domain.Entities
{
    public class Candidate : IEntityBaseAuditable<Guid, Guid>
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Client { get; set; }
        public string Email { get; set; } //Change this to list
        public string Phone { get; set; } //Change this to list
        public string Recruiter { get; set; }
        public string Certification { get; set; } //Change this to list
        public string Location { get; set; }
        public string EducationLevel { get; set; } 
        public string CurrentPosition { get; set; }
        public float SalaryExpectations { get; set; }
        public float CurrentSalaryGross { get; set; }
        public string Skill { get; set; } //Change this to list
        public string Experience { get; set; } 
        public string Language { get; set; } //Change this to list
        public string QuestionAnswer { get; set; } //Change this to list
        public string Notes { get; set; } 
        public string Img { get; set; }
        public string? CV { get; set; }
        public Guid UserModifierId { get ; set; }
        public DateTime DateLastModify { get; set; }
        public bool State { get; set; }
        public Guid UserCreatorId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
