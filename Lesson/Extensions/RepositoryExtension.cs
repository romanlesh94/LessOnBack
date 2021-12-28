using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace Lesson.Extensions
{
    public static class RepositoryExtension
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
                //<IRepository, Repository.Repository>();
        }
    }
}
