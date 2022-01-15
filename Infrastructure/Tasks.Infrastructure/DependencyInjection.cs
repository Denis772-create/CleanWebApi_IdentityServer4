using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tasks.Application.Interfaces;

namespace Tasks.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<MyTasksDbContext>(options => 
                { options.UseSqlite(configuration["DbConnection"]); });
            services.AddScoped<IMyTasksDbContext>(provider => provider.GetService<MyTasksDbContext>());

            return services;
        }
    }
}
