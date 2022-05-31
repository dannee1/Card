# Card App

======================
  
  ## API .NET Core
 
  Register a card.

- Record a card
- Validate a card token;

# Hot to run:
- Latest version of SDK (https://dot.net/core)

 ## Docker
  On the root application path:
  - docker build -t Card .
  - docker run -d -p 8080:80 --name card Card

 ## .NET CLI
  On the root application path:
  dotnet run --project Card.Service\Card.Service.csProj

  Swagger path:
  https://localhost:5001/swagger/index.html
  
  ## info :
  
   - Use of EF Core in memory ( test only ), the data only are available during the execution time.

## Available to CI
- Travis

## Technologies:

- ASP.NET Core 3.1
- ASP.NET MVC Core 
- ASP.NET WebApi Core
- Entity Framework Core 2.1
- Entity Framework Core 2.1 (InMemory)
- .NET Core Native DI
- FluentValidator
- MediatR
- Swagger UI

## Architecture / Patterns:

- Segragated architecture with single responsiblity, using SOLID principles.
- Dependency Injection
- Inversion of control
- Domain Driven Design (Layer and Domain Model Pattern)
- CQRS
- Repository


