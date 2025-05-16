using Flight_Asp.NetCoreWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// CORS access to our website
var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>(); // Fetch from appsettings
if (allowedOrigins == null || allowedOrigins.Length == 0)
{
    throw new InvalidOperationException("AllowedOrigins configuration is missing or empty.");
}

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowConfiguredOrigins",
        policy =>
        {
            policy.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod();
        });
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FlightDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null);
        sqlOptions.CommandTimeout(30); // Set a command timeout
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Enable detailed error pages
    app.MapScalarApiReference();
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowConfiguredOrigins"); // CORS

app.MapControllers();

app.Run();
