using Microsoft.Extensions.DependencyInjection;
using Services;

namespace Lesson.Extensions
{
    public static class AccountServiceExtension
    {
        public static void AddAccountService(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
        }

    }
}
