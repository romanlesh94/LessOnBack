using Microsoft.Extensions.DependencyInjection;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson.Extensions
{
    public static class DbContextExtension
    {
        public static void AddDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>();
        }
    }
}
