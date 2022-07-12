using Microsoft.Extensions.DependencyInjection;
using Services;

namespace LessOn.Extensions
{
    public static class UnitServiceExtension
    {
        public static void AddUnitService(this IServiceCollection services)
        {
            services.AddScoped<IUnitService, UnitService>();
        }
    }
}
