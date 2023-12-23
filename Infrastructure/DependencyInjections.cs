using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Database.SqlDataBases;
using Infrastructure.Repository.Authrepository;
using Infrastructure.Repository.Users;
using Infrastructure.Repository.Animals;
using Infrastructure.Repository.UserAnimal;

namespace Infrastructure
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<MockDatabase>();
            services.AddScoped<AuthRepo>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAnimalRepository, AnimalRepository>();
            services.AddScoped<IUserAnimalRepository, UserAnimalRepository>();



            services.AddDbContext<RealDatabase>(options =>
            {
                options.UseSqlServer("Server=MSI\\SQLEXPRESS; Database=CleanApi_demo_db; Trusted_Connection=true; TrustServerCertificate=true;");

            });
            return services;
        }
    }
}
