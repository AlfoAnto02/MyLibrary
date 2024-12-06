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
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyAllowSpecificOrigins",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200", "https://localhost:7255")
                            .WithHeaders("Content-Type", "Authorization")
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });


            var app = builder.Build();

            app.UseCors("MyAllowSpecificOrigins");
            app.Use(async (context, next) =>
            {
                if (context.Request.Method == "OPTIONS") {
                    context.Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:4200");
                    context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");
                    context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
                    context.Response.StatusCode = 200;
                    await context.Response.CompleteAsync();
                    return;
                }
                await next();
            });
            app.AddWebMiddlewares();
            app.Run();
        }
    }
}
