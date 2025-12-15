# Toggl Platform API

## Description

RESTful API for Toggl Project & Time Management Hub, exposing project listings and time entry registration with localization, integration events, and database seeding.

## Features

- **Projects**: Retrieve seeded projects with workspace, billing, status, and creator information.
- **Time Entries**: Register time entries with validation, duration accumulation, and project status updates when totals exceed 480 minutes.
- **Domain-Driven Design**: Bounded contexts for Projects and TimeEntries with an Anti-Corruption Layer.
- **Localization**: Support for English (EN, EN-US) and Spanish (ES, ES-PE).
- **OpenAPI Documentation**: Swagger UI with operation details.

## Technology Stack

- **Framework**: ASP.NET Core 9.0
- **Language**: C# with .NET 9
- **Database**: MySQL (schema `toggl`)
- **ORM**: Entity Framework Core 9.0
- **Documentation**: Swashbuckle (Swagger/OpenAPI)
- **Patterns**: DDD, CQRS, Repository Pattern, Anti-Corruption Layer, Integration Events

## API Endpoints

### Time Entries
- `POST /api/v1/time-entries` - Register a new time entry.

### Projects
- `GET /api/v1/projects` - Retrieve all projects.

## Getting Started

### Database Configuration

Update the connection string in `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=toggl;User=root;Password=your_password;"
  }
}
```

### Running the Application

1. Restore dependencies:
```bash
dotnet restore
```

2. Run the application:
```bash
dotnet run
```

## Author

**Rafael Oswaldo Castro Veramendi u20211d760**
