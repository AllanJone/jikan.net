# jikan.net

Jikan.net is a .NET wrapper for [Jikan](https://jikan.moe) RESTful API for parsing data from [MyAnimeList](https://myanimelist.com). Main objective of the wrapper is to simplify utilization of Jikan API, as strongly typed languages are not-so-easy to use with elastic json (sure we can go use dynamics in .NET, but let's think about performance).

### Main attributes

* Written in .Net Standard, compatible with .Net Framework and .Net Core.
* Fully asynchromous request fetching (can be forced to synchromous if needed).
* Can handle both SSL encrypted and non-SSL encrypted requests.
* Light on dependencies (require only Newtonsoft.Json for parsing).
* Usable with Dependency Injection.

# List of features

- Basic requests
    - [X] Anime
    - [X] Manga
    - [X] Character
    - [X] People
- Anime extended requests
    - [X] Characters & Staff
    - [X] Episode
    - [X] News
    - [X] Videos/PV/Episodes
    - [X] Pictures
    - [X] Stats
    - [X] Forum Topics
    - [X] More Info
    - [ ] Recommendation
    - [ ] Reviews
- Manga extended requests
    - [X] Characters
    - [X] News
    - [X] Stats
    - [X] Pictures
    - [X] Forum Topics
    - [X] More Info
    - [ ] Recommendation
    - [ ] Reviews
- Character extended requests
    - [X] Pictures
- People Parsing
    - [X] Pictures
- Search (Anime/Manga/Character/Person)
    - [ ] Filters (Advanced Search)
    - [ ] Pagination Support
    - [ ] No.# of pages
- [ ] Seasonal Anime (Season + Year)
- [ ] Anime Scheduling (for current season)
- Top
    - [ ] Anime
    - [ ] Manga
    - [ ] Sub Types & Pagination Support

# Installation

### Package manager

```
PM> Install-Package JikanDotNet -Version 0.2.0
```

### .NET CLI

```
>dotnet add package JikanDotNet --version 0.2.0
```

Then restore dependencies:
```
>dotnet restore
```

# Changelog

## 05.05.2018 - Version 0.2.0

- Extended request for Anime/Manga/Character/Person via extensions.

## 02.05.2018 - Version 0.1.0 (latest)

- First usable version.
- Added basic requests for Anime/Manga/Person/Character.

# Documentation

Coming soon.

# Usage example

## C#

```csharp
// Initialize JikanWrapper
IJikan jikan = new Jikan(true);

// Send request for "Cowboy Bebop" anime
Anime cowboyBebop = jikan.GetAnime(1).Result;

// Output -> "Cowboy Bebop"
Console.WriteLine(cowboyBebop.Title);
// Output -> "TV"
Console.WriteLine(cowboyBebop.Type);
// Output -> "R - 17+ (violence & profanity)"
Console.WriteLine(cowboyBebop.Rating);


// Send request for "Berserk" manga
Manga berserkManga = jikan.GetManga(2).Result;

// Output -> "Berserk"
Console.WriteLine(berserkManga.Title);
// Output -> "Publishing"
Console.WriteLine(berserkManga.Status);


// Send request for Hayao Miyazaki
Person hayaoMiyazaki = jikan.GetPerson(1870).Result;

// List Miyazaki anime on output
foreach (var staffPosition in hayaoMiyazaki.AnimeStaffPositions)
{
    Console.WriteLine("Anime: " + staffPosition.Anime.Name + ", role: " + staffPosition.Role);
}


// Send request for Lain Iwakura
Character lainIwakura = jikan.GetCharacter(2219).Result;

// List Lain's voice actresses with their respective languages
foreach (var voiceActor in lainIwakura.VoiceActors)
{
    Console.WriteLine("Name: " + voiceActor.Name + ", language: " + voiceActor.Language);
}

// List all anime in which Lain appeared
foreach (var anime in lainIwakura.Animeography)
{
    Console.WriteLine("Title: " + anime.Name);
}
```

## VB.NET

```vbnet
Dim jikan As Jikan

' Initialize JikanWrapper
jikan = New Jikan(True)

' Send request for "Cowboy Bebop" anime
Dim cowboyBebop = jikan.GetAnime(1).Result

' Output -> "Cowboy Bebop"
Console.WriteLine(cowboyBebop.Title)
' Output -> "TV"
Console.WriteLine(cowboyBebop.Type)
'Output -> "R - 17+ (violence & profanity)"
Console.WriteLine(cowboyBebop.Rating)


' Send request for "Berserk" manga
Dim berserkManga = jikan.GetManga(2).Result

' Output -> "Berserk"
Console.WriteLine(berserkManga.Title)
' Output -> "Publishing"
Console.WriteLine(berserkManga.Status)

' Send request for Hayao Miyazaki
Dim hayaoMiyazaki = jikan.GetPerson(1870).Result

' List Miyazaki anime on output
For Each staffPosition In hayaoMiyazaki.AnimeStaffPositions
    Console.WriteLine("Anime: " + staffPosition.Anime.Name + ", role: " + staffPosition.Role)
Next


' Send request for Lain Iwakura
Dim lainIwakura = jikan.GetCharacter(2219).Result

' List Lain's voice actresses with their respective languages
For Each voiceActor In lainIwakura.VoiceActors
    Console.WriteLine("Name: " + voiceActor.Name + ", language: " + voiceActor.Language)
Next

' List all anime in which Lain appeared
For Each anime In lainIwakura.Animeography
    Console.WriteLine("Title: " + anime.Name)
Next
```