using Gotorz.Components;
using Gotorz.Services;

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
        builder.Services.AddScoped<IChatHttpService, ChatHttpService>();
        builder.Services.AddScoped<IChatHubService, ChatHubService>();
 
        builder.Services.AddScoped<FlightService>();
        builder.Services.AddScoped<IPackageService, PackageService>();
/*******************************************************************
 * Det her kommer fra HotelConnect ovenstående fra main/packageAPI*
 * ****************************************************************/
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
