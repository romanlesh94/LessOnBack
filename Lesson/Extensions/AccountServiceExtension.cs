using Microsoft.Extensions.DependencyInjection;
using Services;

namespace Lesson.Extensions
{
    public static class ServicesExtension
    {
        public static void AddAccountService(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
        }

    }
}
