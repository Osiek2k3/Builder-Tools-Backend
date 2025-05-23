using BuilderTools.Core.UseCase.BuilderToolCase;
using BuilderTools.Core.UseCase.CategoryCase;
using BuilderTools.Core.UseCase.RentalCase;
using BuilderTools.Core.UseCase.UserCase;
using BuilderTools.Core.UseCase.Validation;
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

            services.AddTransient<AddBuilderToolUseCase>();
            services.AddTransient<EditBuilderToolUseCase>();
            services.AddTransient<GetAllBuilderToolUseCase>();
            services.AddTransient<GetByIdBuilderToolUseCase>();

            services.AddTransient<AddRentalUseCase>();
            services.AddTransient<EditRentalUseCase>();
            services.AddTransient<GetAllRentalUseCase>();
            services.AddTransient<GetByIdRentalUseCase>();


            services.AddTransient<RentalInputDtoValidator>();
            services.AddTransient<RentalValidator>();

            return services;
        }
    }
}
