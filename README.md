# Music BoomBoxd

This project was made in year 1, semester 2 of my studies. It's a desktop and web application for music fans to catalogue albums, songs, and artists; review them; and get recommendations. The name suggests a music version of Letterboxd, the film-review site.

It is a C# / .NET 8 solution with a Windows Forms desktop app and an ASP.NET Core web app, sharing one business-logic layer and one data layer. This was my second personal project, and the first one written in C#.

## Features

**Desktop app (Windows Forms)**
- Login and registration, with password hashing
- Dashboard listing albums, songs, artists, reviews and users
- Add and delete albums, songs, artists and users, with validation
- Log out

**Web app (ASP.NET Core Razor Pages)**
- Register, log in and log out with cookie authentication
- Browse albums, and view album and song reviews
- Add albums and songs through input forms
- Profile page, user balance page, and a page to upgrade an account
- Privacy and error pages

**Logic**
- Recommendations built from filters: favourite genre, favourite artist, and review activity

## Solution structure

```
Main/MusicBoomBoxd/
├── MusicBoomBoxd.sln
├── WinFormsApp/                 # Desktop app (.NET 8, Windows Forms)
├── WebApp/WebApp/               # Web app (.NET 8, ASP.NET Core Razor Pages)
├── Logic/Logic/                 # Business logic: managers, validators, mappers, recommendation filters
├── Infrastructure/              # Data access: repositories, DTOs and the SQL Server connection
└── UnitTestsMusicBoomBoxd/      # MSTest unit tests
```

Project documents are in the repository root:

```
1. Ideation Document/     # Original idea and version 2.0 of the ideation document
2. ProjectPlan/           # Project plan (v2.2, plus older versions)
3. SiteMap/               # Site map for the web app
4. WireFrame/             # Wireframes
5 UML/                    # Class and activity diagrams
6 URS/                    # User requirements specification
7 DB Diagram/             # Database diagrams
8 Test Plan/              # Test plan and test report
9 Usecase/                # Use-case diagram
```

## Tech stack

- .NET 8 (C#, nullable reference types, implicit usings)
- Windows Forms (desktop)
- ASP.NET Core Razor Pages with cookie authentication (web)
- Microsoft SQL Server, via `Microsoft.Data.SqlClient`
- BCrypt.Net-Next for password hashing
- Entity Framework Core 8 package reference (present in the Infrastructure project)
- SixLabors.ImageSharp for images, and Newtonsoft.Json
- MSTest, Moq and coverlet for testing

## Requirements

- Windows, with Visual Studio 2022 and the **.NET desktop development** workload (needed for the WinForms app)
- .NET 8 SDK
- Access to a Microsoft SQL Server database with the BoomBoxd tables

## Database setup

The repository does not include a SQL schema script. The database design is documented in the **7 DB Diagram** folder. To run the app you need a SQL Server database that matches the tables those diagrams describe, with the user tables, albums, songs, artists, reviews and profiles that the repositories query.

Store the connection string in configuration that is not committed. See the Configuration section below.

## Configuration

The connection string appears in two places:

- `Main/MusicBoomBoxd/Infrastructure/DbConnection.cs`
- `Main/MusicBoomBoxd/WebApp/WebApp/appsettings.json`, under `ConnectionStrings:MusicBoomBoxdDB`

The format is:

```
Server=<server>;Database=<database>;User Id=<user>;Password=<password>;TrustServerCertificate=True;
```

For local development, move the connection string into .NET user secrets (for the web app), or read it from an environment variable, and keep the password out of source control.

## Running

1. Clone the repository and open the solution:

   ```
   git clone https://github.com/SzymekHub/music-boomboxd.git
   ```

   Open `Main/MusicBoomBoxd/MusicBoomBoxd.sln` in Visual Studio.

2. Restore NuGet packages (Visual Studio does this on build).

3. Set the startup project:
   - **Desktop app:** right-click `WinFormsApp` and choose *Set as Startup Project*, then press F5. The login screen opens first.
   - **Web app:** right-click `WebApp` and choose *Set as Startup Project*, then press F5. The browser opens the home page.

## Running tests

Open **Test Explorer** in Visual Studio and run the tests in `UnitTestsMusicBoomBoxd`, or run:

```
dotnet test Main/MusicBoomBoxd/UnitTestsMusicBoomBoxd/UnitTestsMusicBoomBoxd.csproj
```

The suite contains 22 test methods. The test project references Moq for mocking dependencies.

## Known limitations

- **Hardcoded database credentials.** The connection string with a username and password is committed in `Infrastructure/DbConnection.cs` and `WebApp/appsettings.json`. Remove them from the code and rotate the password.
- **Leftover code.** The `Logic` folder contains an older CSV-based user repository (`CsvUserRepository.cs`) from before the database layer was added. It is not used by the current app.
- **Duplicate project.** There are two `Logic.csproj` files: one in `Main/MusicBoomBoxd/Logic/` and one in `Main/MusicBoomBoxd/Logic/Logic/`. The solution uses the one in `Logic/Logic/`.
- **Windows only** for the desktop app. The web app would run on other platforms, but the solution is set up for Visual Studio on Windows.

## Project history

This was my second personal project and my first in C#. Early work is in the ideation and project plan folders, and the diagrams show how the design changed across versions.

## Author

Szymon Gancarz. Built as an individual project in the ICT programme at Fontys University of Applied Sciences.
