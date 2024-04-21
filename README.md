# Net Core 8 Starter Template

This repository is my personal starter template for Net Core 8 Web API projects.

## Getting Started

Follow these instructions to get started :

### Installing

1. Clone the repository
2. At the root directory, restore required packages :

```csharp
dotnet restore
```

3. Next, we build the solution :

```csharp
dotnet build
```

4. Next, launch the back end by running:

```csharp
cd API
dotnet run
```

5. Launch http://localhost:5137/swagger/index.html to view the Swagger UI.

## Clean Archictecture

This starter template follows the Clean Architecture. Clean Architecture flips the dependency via dependency injection/inversion such that the outer layers (e.g. API/Infrastructure) depends on abstractions defined by inner core layers (e.g. Application/Domain). This makes it easy if we were to change infrastructure as it will not have as much of an impact on the core business layers.

### Structure of Project

The solution structure and project type is the following :

```
.
├── API (Web API)
├── Core
│ ├── Application (Class Library)
│ └── Domain (Class Library)
├── Infrastructure
│ └── Persistence (Class Library)
└── Tests
├── IntegrationTests (XUnit)
└── UnitTests (XUnit)
```

- The Domain Project will hold all the Entities and Specifications objects.
- The Application Project is where the Contracts will be defined and Business Logic should reside.
- The Persistence Project will be where most Contracts are implemented and where Infrastructural libraries like Entity Framework Core will be implemented.
- Lastly, the API Project will be where we expose the endpoints.

## Design Patterns

- ### CQRS

This starter template implements CQRS with the MediatR library. The Command and Query files are found in the Feature folder of the Application Layer (Vertical Layers) as per Clean Architecture Project Structure.

- ### Module Design Pattern

Based off the article in : https://timdeschryver.dev/blog/maybe-its-time-to-rethink-our-project-structure-with-dot-net-6 .

We can move and group the endpoints out into separate folders and files for better maintainability and we call them modules.
We follow a domain driven approach and group the different domains into modules.

A module will provide two functions RegisterModule() and MapEndpoints() for registering the service dependencies and defining the endpoints respectively.

- ### Specification Design Pattern With Repository Design Pattern

We use the Specification library by Steve Smith/Ardalis. Specifications are implemented at the domain layer.
