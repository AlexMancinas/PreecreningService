using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPersitence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CandidateDbContext>(options => options.UseSqlServer(connectionString));
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(MyRepositoryAsync<>));

            return services;
        }
    }
}
