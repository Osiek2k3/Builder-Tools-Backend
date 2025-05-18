using BuilderTools.Core.UseCase.CategoryCase;
using BuilderTools.Core.UseCase.UserCase;
using Microsoft.Extensions.DependencyInjection;

namespace BuilderTools.Core
{
    public static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddTransient<SignUpUseCase>();
            services.AddTransient<SignInUseCase>();
            services.AddTransient<GetAllUsers>();

            services.AddTransient<AddCategoryUseCase>();
            services.AddTransient<GetByIdCategoryUseCase>();
            services.AddTransient<EditCategoryUseCase>();
            services.AddTransient<GetAllCategoryUseCase>();
            
            return services;
        }
    }
}
