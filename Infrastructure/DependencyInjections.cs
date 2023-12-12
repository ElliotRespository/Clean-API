using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Database.SqlDataBases;

namespace Infrastructure
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<MockDatabase>();

            services.AddDbContext<RealDatabase>(options =>
            {
                options.UseSqlServer("Server=MSI\\SQLEXPRESS; Database=CleanApi_demo_db; Trusted_Connection=true; TrustServerCertificate=true;");

            });
            return services;
        }
    }
}
