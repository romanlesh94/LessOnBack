using Microsoft.Extensions.DependencyInjection;
using Services;

namespace LessOn.Extensions
{
    public static class CardServiceExtension
    {
        public static void AddCardService(this IServiceCollection services)
        {
            services.AddScoped<ICardService, CardService>();
        }
    }
}
