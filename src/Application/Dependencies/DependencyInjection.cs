using System.Reflection;
using Address.API.Application.Common.Behaviors;
using Address.API.Application.Data.Contexts;
using FluentValidation; 
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Address.API.Application.Dependencies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCQRS(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));

            return services;

        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase("AddressDb");
            });

            return services;
        }
    }
}
