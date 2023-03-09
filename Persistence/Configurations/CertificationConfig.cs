using Atos.EFCore.Extensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class CertificationConfig : IEntityTypeConfiguration<Certification>
    {
        public void Configure(EntityTypeBuilder<Certification> builder)
        {
            builder.ConfigurationBase<Guid, Guid, Certification>("Certifications");
            builder.Property(x => x.Id).HasDefaultValue("NEWID()");
            builder.Property(x => x.CertificactionName).HasColumnType("varchar(120)");
            builder.Property(x => x.CertificationDescription).HasColumnType("varchar(120)");
            builder.Property(x => x.CandidateId).HasColumnType("UNIQUEIDENTIFIER").IsRequired();
            builder.Property(x => x.State).HasColumnType("bit");
        }
    }
}
