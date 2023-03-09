using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Atos.EFCore.Extensions;

namespace Persistence.Configurations
{
    public class CandidateConfig : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.ConfigurationBase<Guid, Guid, Candidate>("Candidates");
            builder.Property(x => x.Id).HasDefaultValue("NEWID()");
            builder.Property(x => x.FullName).HasColumnType("varchar(120)");
            builder.Property(x => x.Client).HasColumnType("varvhar(80)");
            builder.Property(x => x.Recruiter).HasColumnType("varchar(30)");
            builder.Property(x => x.Location).HasColumnType("varchar(30)");
            builder.Property(x => x.EducationLevel).HasColumnType("varchar(30)");
            builder.Property(x => x.CurrentPosition).HasColumnType("varchar(30)");
            builder.Property(x => x.SalaryExpectations).HasColumnType("money");
            builder.Property(x => x.CurrentSalaryGross).HasColumnType("money");
            builder.Property(x => x.Experience).HasColumnType("varchar(200)");
            builder.Property(x => x.Notes).HasColumnType("varchar(200)");
            builder.Property(x => x.Img).HasColumnType("varchar(120)");
            builder.Property(x => x.CV).HasColumnType("varchar(120)");
            builder.Property(x => x.State).HasColumnType("bit");
            //Relations
            builder.HasMany(x => x.Emails).WithOne(x => x.Candidate).HasForeignKey(x => x.CandidateId);
            builder.HasMany(x => x.Phones).WithOne(x => x.Candidate).HasForeignKey(x => x.CandidateId);
            builder.HasMany(x => x.Certifications).WithOne(x => x.Candidate).HasForeignKey(x => x.CandidateId);
            builder.HasMany(x => x.Languages).WithOne(x => x.Candidate).HasForeignKey(x => x.CandidateId);
            builder.HasMany(x => x.QuestionsAnswers).WithOne(x => x.Candidate).HasForeignKey(x => x.CandidateId);
        }
    }
}
