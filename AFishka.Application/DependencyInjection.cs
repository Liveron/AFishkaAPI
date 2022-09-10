using AFishka.Application.Common.Mappings;
using FluentValidation;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;



namespace AFishka.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IMapper, EventsMapper>();
            services.AddValidatorsFromAssemblies(new[] {Assembly.GetExecutingAssembly()});
            return services;
        }
    }
}
