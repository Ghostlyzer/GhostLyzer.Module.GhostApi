<h1 align="center">
  <br>
  <a href="https://ghostlyzer.com"><img src="https://raw.githubusercontent.com/Ghostlyzer/GhostLyzer.Module.GhostApi/main/assets/img/github-readme-logo-ghostlyzer.png" alt="GhostLyzer" width="200"></a>
  <br>
  Ghost CMS API .NET SDK
  <br>
</h1>

<h4 align="center">An easy to use C# Wrapper for the Ghost CMS API built on top of <a href="https://dotnet.microsoft.com/en-us/" target="_blank">.NET</a>.</h4>

<p align="center">
  <a href="https://www.codefactor.io/repository/github/ghostlyzer/ghostlyzer.module.ghostapi">
    <img src="https://www.codefactor.io/repository/github/ghostlyzer/ghostlyzer.module.ghostapi/badge"
         alt="CodeFactor">
  </a>
  <a href="https://www.nuget.org/packages/GhostLyzer.Module.Ghostapi"><img src="https://badgen.net/nuget/v/GhostLyzer.Module.Ghostapi"></a>
  <a href="https://github.com/Ghostlyzer/GhostLyzer.Module.GhostApi/blob/main/LICENSE">
      <img src="https://badgen.net/github/license/GhostLyzer/GhostLyzer.Module.GhostApi">
  </a>
  <a href="https://github.com/Ghostlyzer/GhostLyzer.Module.GhostApi/actions/workflows/cicd.yml">
    <img src="https://github.com/Ghostlyzer/GhostLyzer.Module.GhostApi/actions/workflows/cicd.yml/badge.svg?branch=main">
  </a>
  <a href="https://github.com/Ghostlyzer/GhostLyzer.Module.GhostApi/actions/workflows/github-code-scanning/codeql">
    <img src="https://github.com/Ghostlyzer/GhostLyzer.Module.GhostApi/actions/workflows/github-code-scanning/codeql/badge.svg">
  </a>
  <a href="https://github.com/Ghostlyzer/GhostLyzer.Module.GhostApi/actions/workflows/dotnet.yml">
    <img src="https://github.com/Ghostlyzer/GhostLyzer.Module.GhostApi/actions/workflows/dotnet.yml/badge.svg">
  </a>
</p>

<p align="center">
  <a href="#key-features">Key Features</a> •
  <a href="#how-to-use">How To Use</a> •
  <a href="#credits">Credits</a> •
  <a href="#license">License</a>
</p>

<!---![screenshot](https://raw.githubusercontent.com/amitmerchant1990/electron-markdownify/master/app/img/markdownify.gif)--->

## Key Features

At the moment the wrapper supports the following features in the Ghost API. I am working on a new feature to include member functionality.

* **Content API features**
  - [Authors](https://ghost.org/docs/content-api/#authors)
  - [Pages](https://ghost.org/docs/content-api/#pages)
  - [Posts](https://ghost.org/docs/content-api/#posts)
  - [Settings](https://ghost.org/docs/content-api/#settings)
  - [Tags](https://ghost.org/docs/content-api/#tags)
  - [Tiers](https://ghost.org/docs/content-api/#tiers)
* **Admin API features**
  - [Images](https://ghost.org/docs/admin-api/#images)
  - Newsletters
  - [Offers](https://ghost.org/docs/admin-api/#offers)
  - [Pages](https://ghost.org/docs/admin-api/#pages)
  - [Posts](https://ghost.org/docs/admin-api/#posts)
  - [Site](https://ghost.org/docs/admin-api/#site)
  - [Themes](https://ghost.org/docs/admin-api/#themes)
  - [Tiers](https://ghost.org/docs/admin-api/#tiers)
  - [Webhooks](https://ghost.org/docs/admin-api/#webhooks)
  - [Members](https://ghost.org/docs/admin-api/#members) (coming soon)
  - [Users](https://ghost.org/docs/admin-api/#users) (coming soon)

## How To Use

Interested in getting started working with data from your Ghost blog? Awesome! Install the [NuGet](https://www.nuget.org/packages/GhostLyzer.Module.Ghostapi) in your project and use it as shown below.

### Accessing the Content API

If you need to access the Content API, all you need is the URL of your site and a Content API Key, [available on the "Integrations" page](https://ghost.org/docs/content-api/#key). Once you have those pieces of information, you can access any "public" content on your blog.

```csharp
var ghost = new GhostLyzer.Module.GhostApi.GhostContentAPI("https://blog.christian-schou.dk", "<content-api-key-from-ghost-integration>");
var settings = ghost.GetSettings();

Console.WriteLine($"Welcome to {settings.Title}: {settings.Description}\r\n");
Console.WriteLine($"Navigation: {string.Join(", ", settings.Navigation.Select(x => x.Label))}");
```

Output:

```
Welcome to Grant Winney: We learn by doing. We've all got something to contribute.

Navigation: ReadMe, C#, .NET, Docker, Account
```

### Accessing the Admin API

If you need to access the Admin API, all you need is the URL of your site and an Admin API Key, also [available on the "Integrations" page](https://docs.ghost.org/api/content/#key). Once you have those pieces of information, you can access any "private" content.

```csharp
var ghost = new GhostLyzer.Module.GhostApi.GhostAdminAPI("https://blog.christian-schou.dk", 
    "5cf706fd7d4b35066550627a:9e5ed2b90e40f68573b0cdaf4aef666b047fc9837ad285b2e219eed5501bae53");
var site = ghost.GetSite();

Console.WriteLine($"Welcome to <a href='{site.Url}'>{site.Title}</a>\r\n");
Console.WriteLine($"Running Ghost v{site.Version}");
```

Output:

```
Welcome to <a href='https://blog.christian-schou.dk/'>Tech with Christian</a>

Running Ghost v5.79
```

You can optionally pass in a version number for the API (i.e. 4.0), or omit it to default to the latest ([currently 5.0](https://ghost.org/docs/faq/major-versions-lts/)). You are on your own here, if you break the integration, I cannot help you as I simply don't have the time right now. You are more than welcome to fork the project, implement the changes, and make a pull request.

## Running the Tests

The tests are set to run against an actual instance of a live Ghost blog, using a valid API key. There are details in the `TestBase.cs` class that you'll need to fill in, such as a valid API key, valid post ID, valid post slug, etc... I would recommend you set up a new environment variable with your key as that would avoid you to submit any secrets to your repo, making yourself vulnerable.

## Credits

This software uses the following open-source packages:

- [.NET](https://dotnet.microsoft.com/en-us/)
- [Ghost CMS](https://github.com/TryGhost/Ghost)

### Credit To The Original Author

This solution is a rewrite of the original [GhostSharp](https://github.com/grantwinney/GhostSharp) project by [grantwinney](https://github.com/grantwinney).
GhostSharp supports up to .NET 6. This project adds support for .NET 8, async requests, and an updated way of making the requests along with less complexity in the logic behind the requests. If you compare the two of them you would easily find similarities, and that's because it's heavily inspired by what Grant has done in the original project.

I would like to thank Grant for making a great project like GhostSharp! ✌️

## License

MIT


