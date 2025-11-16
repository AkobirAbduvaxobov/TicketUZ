
using AuthSystem.Api.Configurations;
using AuthSystem.Api.Persistense;
using Microsoft.EntityFrameworkCore;

namespace AuthSystem.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.ConfigureDB();
            builder.ConfigureJwt();
            builder.ConfigureDI();

            var app = builder.Build();

            if (true || app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Disable HTTPS only in Docker
            if (!app.Environment.IsDevelopment())
            {
                app.UseHttpsRedirection();
            }


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
