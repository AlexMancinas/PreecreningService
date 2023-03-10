using Application.Behaviours;
using Application.Features.Colaborator.Commands.CreateCandidateCommand;
using Application.Features.Email.Commands.CreateEmailCommnad;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyContainer
    {
        public static void AddApplicaionLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR((configuration => configuration.RegisterServicesFromAssembly(typeof(CreateCandidateCommand).Assembly)));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        }
    }
}
