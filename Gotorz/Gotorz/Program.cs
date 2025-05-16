using Gotorz.Components;
using Gotorz.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddHttpClient<FlightService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:5001");
});
builder.Services.AddHttpClient<HotelService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:5002");
});
builder.Services.AddHttpClient<PackageService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:5003");
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

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
