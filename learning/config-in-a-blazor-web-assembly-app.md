# Problems
Fundamentally, the config system around `appsettings.json` doesn't seem to fit well with a Blazor WebAssembly app. Here are some of the issues:
* The application runs in the browser, so in order to access the config file at runtime the config file must also be available in the browser. So no sensitive data can be stored in it.
* In order for the config file to be available to download, it must be stored in `wwwroot`, not in the project root as you might expect. This means that references to its location must reflect this, for example in the project file when you instruct the build process to publish the config files:
```
<ItemGroup>
  <None Update="wwwroot/appsettings.json">
    <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    <CopyToPublishDirectory>PreserveNewest</CopyToPublishDirectory>
  </None>
  <None Update="wwwroot/appsettings.*.json">
    <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    <CopyToPublishDirectory>PreserveNewest</CopyToPublishDirectory>
  </None>
</ItemGroup>
```
* The config files are not accessible to the application at startup time (I believe because they are loaded from the server asynchronously). Referring to configuration data in `Program.cs`, while setting up DI for example, will simply return `null` values. So this code will fail at runtime:
```
builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]) }); // Configuration["ApiBaseUrl"] is null here!
```
# Solutions
* Don't store any sensitive data in `appsettings.json` and related files!
* Ensure they go in `wwwroot` and the build process publishes them there.
* Inject `IConfiguration` (which is a built-in interface) into things so that config is read at runtime:
```
public class EnvironmentManager : IEnvironmentManager
    {
        private readonly IConfiguration _configuration;

        public EnvironmentManager(IConfiguration configuration, string environmentName)
        {
            _configuration = configuration;
            EnvironmentName = environmentName;
        }
        
        public string ApiBaseUrl => _configuration["ApiBaseUrl"] ?? throw new InvalidOperationException("ApiBaseUrl is not configured.");

        public string EnvironmentName { get; init; }
    }
```
* In the case of this Blazor WebAssembly project I will put production config into `appsettings.json` and provide an `appsettings.Development.json` file so that these settings can be overridden for local development.

# Links
| Link      | Description      |
| ------------- | ------------- |
| https://learn.microsoft.com/en-us/aspnet/core/blazor/fundamentals/configuration?view=aspnetcore-8.0 | Microsoft documentation about handling config in Blazor WebAssembly apps |