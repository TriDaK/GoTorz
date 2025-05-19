using Gotorz.Components;
using Gotorz.Components.Pages;
using Gotorz.Services;
using Gotorz.Services.Api;

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
        builder.Services.AddHttpClient("ChatAPI", client => {
            client.BaseAddress = new Uri("https://localhost:5005"); // Uri to match ChatAPI
        });
        builder.Services.AddScoped<ChatApiService>();
        builder.Services.AddScoped<IChatService, ChatService>();

        builder.Services.AddScoped<FlightService>(); 

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
