using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using BuilderTools.Infrastructure.EF;
using Microsoft.Extensions.Options;
using BuilderTools.Core.Services;
using BuilderTools.Infrastructure.Services;
using BuilderTools.Infrastructure.Repositories;
using BuilderTools.Infrastructure.Exceptions;
using BuilderTools.Core.Model;
using Microsoft.AspNetCore.Identity;

namespace BuilderTools.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PostgresOptions>(configuration.GetSection("postgres"));

            services.AddDbContext<MyDbContext>((serviceProvider, options) =>
            {
                var sqlOptions = serviceProvider.GetRequiredService<IOptions<PostgresOptions>>().Value;
                options.UseNpgsql(sqlOptions.ConnectionString);
            });
            services.AddSingleton<IClock, Clock>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBuilderToolRepository, BuilderToolRepository>();
            services.AddScoped<IRentalRepository, RentalRepository>();
            services
                    .AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>()
                    .AddSingleton<IPasswordManager, PasswordManager>();
            services.AddHttpContextAccessor();
            services.AddScoped<ExceptionMiddleware>();
            return services;
        }

        public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
        {
            var options = new T();
            var section = configuration.GetRequiredSection(sectionName);
            section.Bind(options);

            return options;
        }
    }
}
