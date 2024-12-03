using Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Services;

namespace Application.Extensions {
    public static class ServiceExtension {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration) {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICategoryService, CategoriesService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBookCategoryService, BookCategoryService>();
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }

    }
}
