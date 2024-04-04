using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Logic;
using Infrastructure;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add logging
            builder.Logging.AddConsole();

            // Add services to the container.
            builder.Services.AddRazorPages();

            // Hardcoded connection string
            string connectionString = "Server=mssqlstud.fhict.local;Database=dbi540927_musicboom;User Id=dbi540927_musicboom;Password=MusicBoom1234;";
            builder.Services.AddSingleton(connectionString);

            // Register DbConnection as a singleton
            builder.Services.AddSingleton<DbConnection>();

            // Register UserRepository with the required constructor parameter
            builder.Services.AddScoped<UserRepository>(serviceProvider =>
            {
                // Resolve the connection string and logger from the container
                var connectionString = serviceProvider.GetRequiredService<string>();
                var logger = serviceProvider.GetRequiredService<ILogger<UserRepository>>();

                // Pass the connection string and logger to UserRepository constructor
                return new UserRepository(connectionString, logger);
            });

            // Register UserLogic as a scoped service
            builder.Services.AddScoped<UserLogic>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            // Call OpenConnection method to ensure database connection is attempted
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger<Program>();

                var dbConnection = services.GetRequiredService<DbConnection>();
                dbConnection.OpenConnection(); // Call OpenConnection method
            }

            app.Run();
        }
    }
}