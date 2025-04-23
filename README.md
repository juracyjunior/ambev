# Ambev Developer Evaluation API

## Project Overview

This project is a .NET 8-based API designed for managing orders. It provides endpoints for creating, updating, retrieving, and deleting orders, with a clean architecture and layered design.

---

## Features

- **Order Management**: CRUD operations for orders.
- **Validation**: Input validation using FluentValidation.
- **Logging**: Integrated with Serilog for structured logging.
- **Dependency Injection**: Configured using .NET's built-in DI container.
- **Database Access**: Uses Entity Framework Core for data persistence.
- **Unit Testing**: Comprehensive tests for the application service layer.

## Prerequisites

- .NET 8 SDK
- PostgreSQL database
- Visual Studio 2022 or any compatible IDE

## Configuration

1. **Create Database**: Create a PostgreSQL database and execute the script: `database/ambev.sql`. 

2. **Database Connection**: Update the `ConnectionStrings:DefaultConnection` in `appsettings.json` with your database credentials:
   ```
   "ConnectionStrings": {
      "DefaultConnection": "Host=<host>;Database=<database>;Username=<username>;Password=<password>"
   }
   ```

2. **Logging**: Logs are stored in the `logs/log.txt` file.

## How to Run

1. **Restore Dependencies**:
   ```
   dotnet restore
   ```

2. **Run the Application**:
   ```
   dotnet run --project Ambev.DeveloperEvaluation.Api
   ```

4. **Access the API**:
   - Swagger UI: `https://localhost:<port>/swagger`

## Testing

1. **Run Unit Tests**:
   ```
   dotnet test
   ```

## API Endpoints

### Orders
- **GET** `/orders`: Retrieve all orders.
- **GET** `/orders/{id}`: Retrieve a specific order by ID.
- **POST** `/orders`: Create a new order.
- **PUT** `/orders/{id}`: Update an existing order.
- **DELETE** `/orders/{id}`: Delete an order.

## Additional Notes

- Discounts are calculated based on item quantity:
  - Quantity < 4: No discount.
  - Quantity 4-9: 10% discount.
  - Quantity 10-20: 20% discount.

- The project uses AutoMapper for object mapping and FluentValidation for input validation.

---

Feel free to reach out for any questions or issues!
