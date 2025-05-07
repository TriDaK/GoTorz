using Microsoft.EntityFrameworkCore;
using Package_Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// CORS access to our website // TEMPORARY UNTIL JWT TOKEN IMPLEMENTED !!!!!!!!!!!!!!!!!!!!
var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>(); 

builder.Services.AddCors(options => // TEMPORARY UNTIL JWT TOKEN IMPLEMENTED !!!!!!!!!!!!!!!!!!!!
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

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowConfiguredOrigins"); // CORS // TEMPORARY UNTIL JWT TOKEN IMPLEMENTED !!!!!!!!!!!!!!!!!!!!

app.MapControllers();

app.Run();
