﻿using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace LessOn.Extensions
{
    public static class RepositoryExtension
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
