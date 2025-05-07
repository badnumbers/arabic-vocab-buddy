# Sources of information
* https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/blazor/progressive-web-app.md
* Copilot

# Install dotnet

    sudo snap install dotnet-sdk

# Create a Blazor project

    dotnet new blazorwasm -o Arabic --pwa


This will create a directory called `Arabic` containing a simple application, which you might then have to look for and add to Visual Studio Code. In my case, it created it in `/home`, i.e. the directory above `/Documents`.

# Running the application

    dotnet build

Will build it so that you can check for build errors.

    dotnet run

Will run the server. You should see output like:

    Building...
    info: Microsoft.Hosting.Lifetime[14]
    Now listening on: http://localhost:5281
    info: Microsoft.Hosting.Lifetime[0] Application started. Press Ctrl+C to shut down.
    info: Microsoft.Hosting.Lifetime[0] Hosting environment: Development info: Microsoft.Hosting.Lifetime[0] Content root path: /home/badnumbers/Arabic

You can see a localhost URL in the output. You can click on that to run the application in a browser. If that doesn't connect, the server isn't running anymore, probably because you've used `Ctrl + C` to try and copy something out of the terminal and that's killed it.

# Setting it to run when you press F5

* Install the **C#** extension - this will enable .NET debugging
* It prompted me to install **C# Dev Kit** as well, so I did
* Add the folder `.vscode` to the project if it's not there
* Add the file `launch.json` to `.vscode`
* Put in the following content:

```
{
  "version": "0.2.0",
  "configurations": [
    {
      "name": "Blazor Debug",
      "type": "blazorwasm",
      "request": "launch",
      "url": "http://localhost:5281",
      "browser": "edge",
      "timeout": 60000
    }
  ]
}
```

The port number should match that quoted under `profiles.http.applicationUrl` in `Properties/launchSettings.json`.

If `F5` doesn't work, don't forget to fall back to `dotnet run`. If you see an exception like this:

```
fail: Microsoft.Extensions.Hosting.Internal.Host[11] Hosting failed to start System.IO.IOException: Failed to bind to address http://127.0.0.1:5281: address already in use.
```

Run this command to find out the ID of the process using the port:

```
sudo netstat -tulnp | grep 5281
```

Where obviously 5281 is the expected port number. If netstat isn't installed, use:

```
sudo apt install net-tools
```

For output like:

```
tcp 0 0 127.0.0.1:5281 0.0.0.0:* LISTEN 6388/dotnet tcp6 0 0 ::1:5281 :::* LISTEN 6388/dotnet
```

... the process ID is **6388**. Kill it using:

```
sudo kill -9 6388
```