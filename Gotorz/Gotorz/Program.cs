using Gotorz.Components;
using Gotorz.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient(); // for the API call

//chat
builder.Services.AddHttpClient("ChatAPI", (sp, client) =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    var baseUrl = config["Urls:ChatApi"];
    client.BaseAddress = new Uri(baseUrl);
});
builder.Services.AddScoped<IChatHttpService, ChatHttpService>();
builder.Services.AddScoped<IChatHubService, ChatHubService>();

//flight
builder.Services.AddHttpClient<FlightService>("FlightAPI", (sp, client) =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    var baseUrl = config["Urls:FlightApi"];
    client.BaseAddress = new Uri(baseUrl);
});
builder.Services.AddScoped<FlightService>();

//hotel
builder.Services.AddHttpClient<HotelService>("HotelAPI", (sp, client) =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    var baseUrl = config["Urls:HotelApi"];
    client.BaseAddress = new Uri(baseUrl);
});
builder.Services.AddScoped<HotelService>();

//package
builder.Services.AddHttpClient<PackageService>("PackageAPI", (sp, client) =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    var baseUrl = config["Urls:PackageApi"];
    client.BaseAddress = new Uri(baseUrl);
});
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
