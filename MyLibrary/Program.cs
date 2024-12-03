using System.Reflection;
using MyLibrary.Extensions;
using Models.Extensions;
using Application.Extensions;
using Application.Options;

namespace MyLibrary {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services
                .AddWebervices(builder.Configuration)
                .AddModelServices(builder.Configuration)
                .AddApplicationServices(builder.Configuration);
            builder.Services.Configure<HashingSettings>(builder.Configuration.GetSection("Hashing"));



            var app = builder.Build();

            app.AddWebMiddlewares();
            app.Run();
        }
    }
}
