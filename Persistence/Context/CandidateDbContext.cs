using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class CandidateDbContext : DbContext
    {
        public CandidateDbContext(DbContextOptions options) : base(options) { }
        



        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<QuestionsAnswer> QuestionsAnswers { get; set; }
        public DbSet<Language> Languages { get; set; }
    }
}
