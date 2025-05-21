using Gotorz.Components;
using Gotorz.Components.Pages;
using Gotorz.Services;

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
        
        builder.Services.AddHttpClient("ChatAPI", (sp,client) => {
            var config = sp.GetRequiredService<IConfiguration>();
            var baseUrl = config["Urls:ChatApi"];
            client.BaseAddress = new Uri(baseUrl);
        });
        builder.Services.AddScoped<ChatHttpService>();
        builder.Services.AddScoped<IChatHubService, ChatHubService>();
 
        builder.Services.AddScoped<FlightService>();
        builder.Services.AddScoped<IPackageService, PackageService>();

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
