using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ArabicVocabBuddy.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// dotnet run sets `builder.HostEnvironment.Environment` to "Development" by default
// to get the App Service to set `builder.HostEnvironment.Environment` to "Production", in the Azure Portal, set the environment variable:
/// ASPNETCORE_ENVIRONMENT=Production            
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                     .AddJsonFile($"appsettings.{builder.HostEnvironment.Environment}.json", optional: true, reloadOnChange: false);

//builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]) });

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IEnvironmentManager>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    return new ArabicVocabBuddy.Client.EnvironmentManager(config, builder.HostEnvironment.Environment);
});

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

await builder.Build().RunAsync();
