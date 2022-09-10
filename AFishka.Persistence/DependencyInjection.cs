using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using AFishka.Application.Interfaces;

namespace AFishka.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbConnection");
            services.AddDbContext<EventsDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddScoped<IEventsDbContext>(provider =>
                provider.GetService<EventsDbContext>());
            return services;
        }
    }
}
