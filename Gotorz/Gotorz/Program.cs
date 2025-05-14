using Gotorz.Components;
using Gotorz.Components.Pages;
using Gotorz.Hubs;
using Gotorz.Services;
using Microsoft.AspNetCore.ResponseCompression;

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
        builder.Services.AddResponseCompression(options => ////////////////////////////////////////////////////////////////////////////////
        {
            options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/octet-stream" }); // comprimantes what is sent to and from the server
        });

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

        app.MapHub<ChatHub>("/chathub"); ///////////////////////////////////////////////////////////////////////////////

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}
