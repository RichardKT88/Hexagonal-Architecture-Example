# HexagonalArchitectureExample

## Overview
This project demonstrates a Hexagonal Architecture (Ports & Adapters) implementation in C# for a banking system. It showcases clean separation of concerns, testability, and flexibility in choosing infrastructure components.

## Architecture Diagram

![](/docs/images/diagram.jpg)

## Key Features
- Clean separation of business logic from infrastructure concerns

- Testable core domain with mockable adapters

- Swappable implementations for persistence and external services

- Modern C# practices with async/await throughout

Configuration via .NET Core's options pattern

## Solution Structure
![](/docs/images/solution_structure.jpg)

## Getting Started
### Prerequisites
- .NET 9.0+ SDK

- Docker (for optional database container)

- Fixer.io API key (for exchange rates)

### Installation
1. Clone the repository:

```
git clone https://github.com/your-repo/hexagonal-banking.git
cd hexagonal-banking
```
2. Run the database (SQL Server in Docker):
```
docker run -v ~/docker --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=1q2w3e4r@#$" -p 1433:1433 -d mcr.microsoft.com/mssql/server
```
3. Apply database migrations:
```
dotnet ef database update --project Infrastructure/Persistence
```
4. Run the application:
```
dotnet run --project API/WebAPI
```

## Key Components
### Core Layer
- AccountService: Handles core banking operations

- IAccountRepository: Persistence port

- INotificationService: Notification port

- IExchangeRateService: Currency conversion port

### Infrastructure Adapters
- EntityFrameworkAccountRepository: SQL Server implementation

- SmtpNotificationService: Email notifications

- FixerExchangeRateService: Real-time exchange rates

### API Endpoints
- POST /api/accounts: Create new account - To be Done

- POST /api/accounts/transfer: Transfer funds between accounts

- GET /api/accounts/{id}: Get account details - To be Done

## Testing
Run unit tests:
```
dotnet test
```

## Configuration
Key configuration values in appsettings.json:

```
{
  "ConnectionStrings": {
    "HexArchConnectionString": "Server=localhost;Database=Banking;User=sa;Password=your_password;"
  },
  "SmtpSettings": {
    "Server": "smtp.example.com",
    "Port": 587,
    "Username": "your_email@example.com",
    "Password": "your_password",
    "FromEmail": "noreply@yourbank.com"
  },
  "FixerSettings": {
    "ApiKey": "your_fixer_api_key",
  }
}
```
## Design Patterns Used
- Hexagonal Architecture: Core business logic isolated from infrastructure

- Dependency Injection: Loose coupling between components

- Repository Pattern: Abstract data access

- Options Pattern: Type-safe configuration

