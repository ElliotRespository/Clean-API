using Application.Dtos.User;
using Application.Services.PasswordHasher;
using Application.Services.User;
using Application.Services.UserAnimal;
using Application.Services.UserAnimalService;
using Application.Validators.User;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssembly(assembly);
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddTransient<IValidator<UserInfoDto>, UserValidator>();
            services.AddScoped<IUserAnimalService, UserAnimalService>();



            return services;
        }
    }
}
