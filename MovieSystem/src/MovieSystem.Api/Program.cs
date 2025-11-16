
using Microsoft.EntityFrameworkCore;
using MovieSystem.Api.Configurations;
using MovieSystem.Api.Persistense;

namespace MovieSystem.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.ConfigureDB();
            builder.ConfigureDI();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (true || app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            // Disable HTTPS redirection in Docker
            if (!app.Environment.IsDevelopment())
            {
                app.UseHttpsRedirection();
            }

            // Auto migrate DB
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                db.Database.Migrate();
            }


            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
