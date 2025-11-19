
using APIGateway.Api.Configurations;

namespace APIGateway.Api;

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
        builder.Services.RegisterHttpClientServices(builder.Configuration);
        builder.Services.ConfigureDI();
        //builder.Services.AddJwtAuthentication(builder.Configuration);

        var app = builder.Build();

        // Disable HTTPS redirection in Docker
        if (!app.Environment.IsDevelopment())
        {
            app.UseHttpsRedirection();
        }

        // Configure the HTTP request pipeline.
        if (true || app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
