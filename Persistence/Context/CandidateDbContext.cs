using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class CandidateDbContext : DbContext
    {
        public CandidateDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<Candidate> Candidates { get; set; }
    }
}
