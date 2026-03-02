# API-Biblio

A small ASP.NET Core Web API for a library system (clients, books, and reservations). It exposes CRUD-style endpoints and uses Entity Framework Core with SQL Server.

## Features
- Manage clients, books, and reservations
- SQL Server persistence via EF Core
- Swagger UI in Development
- Simple xUnit tests using EF Core InMemory

## Tech Stack
- .NET 7 / ASP.NET Core Web API
- Entity Framework Core (SQL Server + InMemory for tests)
- Swagger (Swashbuckle)
- Docker (SQL Server container)
- SonarQube + Jenkins (optional via docker-compose)

## Project Structure
- `Controllers/` API controllers (Cliente, Livro, Reserva)
- `Models/` Domain models
- `DataAccess/` EF Core `DbContext`
- `testes/` xUnit tests
- `docker-compose.yml` SQL Server + SonarQube + Jenkins

## API Endpoints
Base URL (local): `http://localhost:5000`

Clients
- `POST /api/Cliente` create client
- `GET /api/Cliente/{id}` get by id
- `DELETE /api/Cliente/{id}` delete by id

Books
- `POST /api/Livro` create book
- `GET /api/Livro/{id}` get by id
- `DELETE /api/Livro/{id}` delete by id

Reservations
- `POST /api/Reserva` create reservation
- `GET /api/Reserva/{id}` get by id (includes client and book)
- `DELETE /api/Reserva/{id}` delete by id
- `GET /api/Reserva/{idCliente}/Livros` list reservations for a client

## Configuration
Connection string lives in `appsettings.json` under `ConnectionStrings:DefaultConnection`.
Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=webApi;User Id=sa;Password=A_Sua_Password;TrustServerCertificate=true;"
  }
}
```

## Run Locally
1. Start SQL Server (Docker):

```bash
docker compose up -d db
```

2. Run the API:

```bash
dotnet run
```

The API listens on `http://localhost:5000` and Swagger UI is available in Development at:
`http://localhost:5000/swagger`

## Run Tests
```bash
dotnet test
```

## SonarQube (Optional)
Start SonarQube via Docker:

```bash
docker compose up -d sonarqube
```

Then run `sonar_scan.bat` on Windows. Replace the token inside the script with your own SonarQube token.

## Notes
- `Reserva` requires valid `ClienteId` and `LivroId`.
- `POST` endpoints reject payloads that already include an `Id`.

## License
Not specified.
