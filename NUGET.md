# Spotify.NetStandard.Sdk

Spotify API .NET Standard SDK Library

## Documentation and Source Code

Project Documentation and Source Code can be found at [https://github.com/RoguePlanetoid/Spotify-NetStandard-Sdk](https://github.com/RoguePlanetoid/Spotify-NetStandard-Sdk)

## NuGet

To add to your project from [nuget.org](https://www.nuget.org/packages/Spotify.NetStandard.Sdk/) use:
```
Install-Package Spotify.NetStandard.Sdk
```

## Example

```c#
using Spotify.NetStandard.Sdk;

var client = SpotifySdkClientFactory
    .CreateSpotifySdkClient(
        "client-id",
        "client-secret");
var request = new AlbumsRequest()
{
    AlbumType = AlbumType.NewReleases
};
var albums = await client.ListAlbumsAsync(request);
foreach (var album in albums.Items)
{
    ...
}
```

## Client Id and Client Secret

You can get a "client-id" and "client-secret" from [developer.spotify.com/dashboard](https://developer.spotify.com/dashboard/) by signing in with your Spotify Id then creating an Application.

## Change Log

### Version 1.0.0

- Initial Release
