using Blazored.SessionStorage;
using Gotorz.Components;
using Gotorz.Components.Pages;
using Gotorz.Services;
using Gotorz.Services.Http;

namespace Gotorz;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();
        builder.Services.AddHttpClient(); // for the API call
        builder.Services.AddScoped<FlightService>();
        builder.Services.AddScoped<LoginService>();
        // Auth service setup
        builder.Services.AddScoped<ITokenService, SessionStorageTokenService>();
        builder.Services.AddHttpClient("AuthorizedAPI", client => {
            client.BaseAddress = new Uri("https://localhost:7039"); // Uri to match AuthAPI
        }).AddHttpMessageHandler<AuthorizationMessageHandler>();
        builder.Services.AddBlazoredSessionStorage();

        var app = builder.Build(); 

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}
