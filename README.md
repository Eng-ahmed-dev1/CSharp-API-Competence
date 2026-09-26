# C# API Competence - E-Commerce API

A modular ASP.NET Core Web API built with clean separation of concerns (.NET 10), implementing an E-Commerce backend service.

## Architecture

The solution follows a multi-tier architecture:

- **ECommerec.API**: Web API controllers, custom filters, and configuration.
- **ECommerec.BLL**: Business Logic Layer containing service implementations, DTOs, and mappings.
- **ECommerec.DAL**: Data Access Layer containing Entity Framework Core DbContext, entities, repositories, and migrations.

## Tech Stack

- **.NET 10**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **Microsoft SQL Server**

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/)
- SQL Server (or SQL Server Docker container)

### Setup & Run

1. Clone the repository:
   ```bash
   git clone https://github.com/Eng-ahmed-dev1/CSharp-API-Competence.git
   cd CSharp-API-Competence
   ```

2. Update database connection string in `src/ECommerec.API/appsettings.json` if needed.

3. Apply database migrations:
   ```bash
   dotnet ef database update --project src/ECommerec.DAL --startup-project src/ECommerec.API
   ```

4. Run the API:
   ```bash
   dotnet run --project src/ECommerec.API
   ```
