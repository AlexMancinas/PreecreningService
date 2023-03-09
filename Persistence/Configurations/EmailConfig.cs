using Atos.EFCore.Extensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class EmailConfig : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.ConfigurationBase<Guid, Guid, Email>("Emails");
            builder.Property(x => x.Id).HasDefaultValue("NEWID()");
            builder.Property(x => x.CandidateId).HasColumnType("UNIQUEIDENTIFIER").IsRequired();
            builder.Property(x => x.State).HasColumnType("bit");
            //builder.Property(x => x.EmailAddress).HasColumnType("varchar(120)");  // Check this error
        }
    }
}
