using Atos.EFCore.Extensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class SkillConfig : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ConfigurationBase<Guid, Guid, Skill>("Skills");
            builder.Property(x => x.Id).HasDefaultValue("NEWID()");
            builder.Property(x => x.SkillName).HasColumnType("varchar(120)");
            builder.Property(x => x.SkillDescription).HasColumnType("varchar(120)");
            builder.Property(x => x.CandidateId).HasColumnType("UNIQUEIDENTIFIER").IsRequired();
            builder.Property(x => x.State).HasColumnType("bit");
        }
    }
    
}
