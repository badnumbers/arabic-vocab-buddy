# How the hosting works
The Blazor WebAssembly app is hosted as static files within the `wwwroot` folder of the API. This simplies hosting (just the one app service) and prevents any CORS issues when the Blazor app makes calls to the API. Some details can be read [here](https://dev.to/gopkumr/hosting-blazor-webassembly-on-asp-net-core-5gd5).

# Magic project reference
Add a project reference from the API project to the Blazor project:
```
<ProjectReference Include="..\ArabicVocabBuddy.Client\ArabicVocabBuddy.Client.csproj" />
```
This ensures that when you publish the API project, it also publishes the Blazor project and copies the publish output of the Blazor project into `wwwroot` of the API project.

# Links
https://dev.to/gopkumr/hosting-blazor-webassembly-on-asp-net-core-5gd5


