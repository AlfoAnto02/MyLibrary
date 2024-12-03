using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models.Context;
using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Extensions {
    public static class ServiceExtension {
        public static IServiceCollection AddModelServices(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<MyDBContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("MyDBContext"));
            });
            services.AddScoped<BookCategoryRepository>();
            services.AddScoped<BookRepository>();
            services.AddScoped<CategoryRepository>();
            services.AddScoped<UserRepository>();
            return services;
        }

    }
}
