using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ArabicVocabBuddy.Client;
using System.Text.Json;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// dotnet run sets `builder.HostEnvironment.Environment` to "Development" by default
// Otherwise it's whatever the environment variable ASPNETCORE_ENVIRONMENT is set to.
// And I guess that defaults to "Production" if not set, as it's not currently set in the app service I'm using

var appSettingsFilename = builder.HostEnvironment.IsDevelopment() ? "appsettings.Development.json" : "appsettings.json";
builder.Configuration.AddJsonFile(appSettingsFilename, optional: false, reloadOnChange: false); 

string? apiBaseUrl;
using (var http = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
{
    var configJson = await http.GetStringAsync(appSettingsFilename);
    using var doc = JsonDocument.Parse(configJson);
    apiBaseUrl = doc.RootElement.GetProperty("ApiBaseUrl").GetString();
}

builder.Services.AddScoped<IEnvironmentManager>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    return new EnvironmentManager(config, builder.HostEnvironment.Environment);
});
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseUrl!) });

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

await builder.Build().RunAsync();
