using Atos.EFCore.Extensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class LanguageConfig : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ConfigurationBase<Guid, Guid, Language>("Languages");
            builder.Property(x => x.Id).HasDefaultValue("NEWID()");
            builder.Property(x => x.LanguageName).HasColumnType("varchar(120)");
            builder.Property(x => x.LanguageLevel).HasColumnType("varchar(120)");
            builder.Property(x => x.CandidateId).HasColumnType("UNIQUEIDENTIFIER").IsRequired();
            builder.Property(x => x.State).HasColumnType("bit");
        }
    }
    
    
}
