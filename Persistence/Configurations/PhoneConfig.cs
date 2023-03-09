using Atos.EFCore.Extensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class PhoneConfig : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.ConfigurationBase<Guid, Guid, Phone>("Phones");
            builder.Property(x => x.Id).HasDefaultValue("NEWID()");
            builder.Property(x => x.PhoneNumber).HasColumnType("varchar(120)");
            builder.Property(x => x.CandidateId).HasColumnType("UNIQUEIDENTIFIER").IsRequired();
            builder.Property(x => x.State).HasColumnType("bit");
        }
    }
    
    
}
