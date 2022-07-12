using Microsoft.Extensions.DependencyInjection;
using Services;

namespace LessOn.Extensions
{
    public static class CardsetServiceExtension
    {
        public static void AddCardsetService(this IServiceCollection services)
        {
            services.AddScoped<ICardsetService, CardsetService>();
        }
    }
}
