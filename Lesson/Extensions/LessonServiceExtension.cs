using Microsoft.Extensions.DependencyInjection;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessOn.Extensions
{
    public static class LessonServiceExtension
    {
        public static void AddLessonService(this IServiceCollection services)
        {
            services.AddScoped<ILessonService, LessonService>();
        }
    }
}
