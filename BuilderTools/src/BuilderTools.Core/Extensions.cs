using BuilderTools.Core.UseCase;
using Microsoft.Extensions.DependencyInjection;

namespace BuilderTools.Core
{
    public static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddTransient<SignUpClientUseCase>();
            services.AddTransient<SignUpCompanyUseCase>();
            services.AddTransient<SignInUseCase>();
            services.AddTransient<GetAllUsers>();
            
            return services;
        }
    }
}
