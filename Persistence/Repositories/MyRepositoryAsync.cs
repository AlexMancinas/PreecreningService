using Application.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class MyRepositoryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
    {
        private readonly CandidateDbContext _context;
        public MyRepositoryAsync(CandidateDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
