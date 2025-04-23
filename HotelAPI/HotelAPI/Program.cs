using HotelAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            
            // CORS access to our website
            var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>(); // henter fra appsettings

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowConfiguredOrigins",
                    policy =>
                    {
                        policy.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod();
                    });
            });

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle   
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<HotelDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("AllowConfiguredOrigins"); // CORS 

            app.MapControllers();

            app.Run();
        }
    }
}
