using Application.Interfaces;
using Atos.Core.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Persistence.Context
{
    public class CandidateDbContext : DbContext
    {
        private readonly IDateTimeService _dateTime;

        public CandidateDbContext(DbContextOptions options, IDateTimeService dateTime) : base(options) 
        {
            _dateTime = dateTime;
        }


        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<QuestionsAnswer> QuestionsAnswers { get; set; }
        public DbSet<Language> Languages { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellation = new CancellationToken())
        {
            //TODO: agregar despues la AuditableEntityBase
            foreach (var entry in base.ChangeTracker.Entries<IEntityBase<Guid, Guid>>())
            {
                switch (entry.State)
                {
                    //TODO: Investigar sobre HTTPContext para pasar datos para recibir por aqui el Guid de la persona                   
                    //Para no tenerlo hardcodeado
                    case EntityState.Added:
                        entry.Entity.CreatedDate = _dateTime.NowUtc;
                        entry.Entity.State = true;
                        //entry.Entity.UserCreatorId = new Guid("ceb6291c-e5fb-46db-b8c0-31fa4616dc0b");
                        break;
                    //case EntityState.Modified:                   
                    //    break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellation);
        }
    }
}
