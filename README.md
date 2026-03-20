# GameStore

Small ASP.NET Core minimal API project for managing games. The app currently exposes CRUD endpoints for `/games`, validates create and update requests, and includes SQLite/EF Core setup with an initial migration.

## Current Status

- `GET`, `POST`, `PUT`, and `DELETE` endpoints exist under `/games`
- Request validation is enabled with data annotations
- SQLite is configured through Entity Framework Core
- Migrations run automatically on startup
- A `games.http` file is included for the VS Code REST Client extension

Important: the API routes currently operate on an in-memory list in [`GameStore.Api/Endpoints/GamesEndpoints.cs`](/home/cpepes/dev/tutorials/gamestore/GameStore.Api/Endpoints/GamesEndpoints.cs). The EF Core `DbContext`, models, and migration are already in place, but the routes are not using the database yet.

## Tech Stack

- .NET 10
- ASP.NET Core Minimal APIs
- Entity Framework Core
- SQLite

## Project Structure

```text
.
├── GameStore.Api
│   ├── Data
│   ├── Dtos
│   ├── Endpoints
│   ├── Models
│   └── Program.cs
├── games.http
└── GameStore.slnx
```

## Getting Started

### Prerequisites

- .NET 10 SDK

### Run the API

From the repository root:

```bash
dotnet run --project GameStore.Api
```

The default development URL is:

```text
http://localhost:5116
```

If the local SQLite database does not exist yet, it will be created on startup and the initial migration will be applied automatically.

## API Endpoints

Base URL:

```text
http://localhost:5116
```

### Get all games

```http
GET /games
```

### Get a game by id

```http
GET /games/{id}
```

Returns `404 Not Found` when the game does not exist.

### Create a game

```http
POST /games
Content-Type: application/json
```

Example body:

```json
{
  "name": "Super Mario Bros. Wonder",
  "genre": "Platformer",
  "price": 59.99,
  "releaseDate": "2023-10-20"
}
```

Returns `201 Created` on success.

### Update a game

```http
PUT /games/{id}
Content-Type: application/json
```

Returns `404 Not Found` when the game does not exist.

### Delete a game

```http
DELETE /games/{id}
```

## Validation Rules

Both create and update requests currently enforce:

- `name`: required, maximum 50 characters
- `genre`: required, maximum 20 characters
- `price`: required, range `1` to `100`
- `releaseDate`: required

## Database

SQLite is configured in [`GameStore.Api/Program.cs`](/home/cpepes/dev/tutorials/gamestore/GameStore.Api/Program.cs) with:

```text
Data Source=GameStore.db
```

The project already contains:

- `GameStoreContext`
- `Game` and `Genre` entity models
- an initial EF Core migration under `GameStore.Api/Data/Migrations`

Local database files are ignored through `.gitignore`.

## REST Client

The repository includes [`games.http`](/home/cpepes/dev/tutorials/gamestore/games.http), which can be used directly with the VS Code REST Client extension to exercise the current endpoints.
