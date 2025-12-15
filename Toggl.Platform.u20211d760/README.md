# Toggl Platform API

## Description

RESTful API for LetPot Smart Self-Watering Planter operations. This API provides endpoints for managing pot data records and pot information, supporting the LetPot ecosystem for intelligent plant care.

## Features

- **Data Records Management**: Create and track pot operation data including humidity levels, operation modes, and phases
- **Pot Management**: Retrieve information about registered pots in the system
- **Domain-Driven Design**: Clean architecture with bounded contexts (TimeEntries and Projects)
- **Event-Driven**: Integration events for cross-context communication
- **Localization**: Support for English (EN, EN-US) and Spanish (ES, ES-PE)
- **OpenAPI Documentation**: Comprehensive API documentation with Swagger UI

## Technology Stack

- **Framework**: ASP.NET Core 9.0
- **Language**: C# with .NET 9
- **Database**: MySQL
- **ORM**: Entity Framework Core 9.0
- **Documentation**: Swashbuckle (Swagger/OpenAPI)
- **Patterns**: DDD, CQRS, Repository Pattern, Anti-Corruption Layer

## Bounded Contexts

### TimeEntries Context
Manages data records from pots, including:
- Operation modes (STAND_BY, OPERATING)
- Operation phases (WAITING, WATERING)
- Humidity level tracking
- Emission timestamps

### Projects Context
Manages pot information, including:
- Pot registration and MAC addresses
- Customer associations
- Preferred humidity levels

## API Endpoints

### Data Records
- `POST /api/v1/data-records` - Create a new data record

### Pots
- `GET /api/v1/pots` - Retrieve all pots

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

## Database Schema

The application uses Entity Framework Core with automatic migrations. The database schema `toggl` will be created automatically on first run with the following tables:
- `data_records` - TimeEntries data from pots
- `pots` - Pot information and preferences

## Business Rules

- MAC addresses must follow format: XX-XX-XX-XX-XX-XX
- Target humidity levels must be between 40.0 and 90.0
- Humidity levels must be positive values
- EmittedAt cannot be in the future
- Data records can only be created for existing pots
- Preferred humidity levels are automatically updated when new target levels are set

## Author

**Antonio Rodrigo Duran Diaz u20211d760**

