using Atos.EFCore.Extensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class QuestionAnswerConfig : IEntityTypeConfiguration<QuestionsAnswer>
    {
        public void Configure(EntityTypeBuilder<QuestionsAnswer> builder)
        {
            builder.ConfigurationBase<Guid, Guid, QuestionsAnswer>("QuestionsAnswers");
            builder.Property(x => x.Id).HasDefaultValue("NEWID()");
            builder.Property(x => x.Answer).HasColumnType("varchar(200)");
            builder.Property(x => x.CandidateId).HasColumnType("UNIQUEIDENTIFIER").IsRequired();
            builder.Property(x => x.State).HasColumnType("bit");
        }
    }
    
}
