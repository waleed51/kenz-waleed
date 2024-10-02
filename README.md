# KanzWay Screening API

## Overview
This project is a REST API that provides a screening result based on a number input. The API follows these rules:
- If the number is divisible by 3, it returns "Kanz".
- If the number is divisible by 5, it returns "Way".
- If the number is divisible by both 3 and 5, it returns "KanzWay".
- Otherwise, it returns the number itself.

## Prerequisites
- .NET 8 SDK
- Git

## Developer notes
I aimed to deliver a high-quality solution within the time constraints. Despite the tight schedule, I believe the outcome reflects modern development practices and technologies. Below are some of the key principles and methodologies I adhered to throughout the project:

- Clean Code: Focused on writing readable, maintainable, and efficient code.
- Separation of Concerns: Ensured clear division of responsibilities across different layers of the application.
- Git Workflow: Followed a structured Git workflow with meaningful commits and proper branching.
- Clean Architecture: Employed a Clean Architecture approach, emphasizing Domain-Driven Design (DDD).
- SOLID Principles & Design Patterns: Applied SOLID principles and relevant design patterns to ensure scalability and maintainability.
- CQRS & MediatR: Utilized the CQRS pattern with MediatR to handle complex application flows and command/query separation.
- API Documentation: Provided comprehensive API documentation using Swagger UI for easy exploration and testing of endpoints.

## How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/kanz-waleed/KanzWayScreening.git

## Project hierarchy
KanzWayScreening
├── src
│   ├── KanzWayScreening.API
│   │   ├── Controllers
│   │   │   └── ScreeningController.cs
│   │   ├── appsettings.json
│   │   ├── KanzWayScreening.API.http
│   │   └── Program.cs
│   ├── KanzWayScreening.Application
│   │   ├── Common
│   │   └── Screening
│   ├── KanzWayScreening.Domain
│   │   └── Entities
│   ├── KanzWayScreening.Infrastructure
│   │   └── Class1.cs
├── tests
│   ├── KanzWayScreening.IntegrationTests
│   │   ├── Factories
│   │   │   └── CustomWebApplicationFactory.cs
│   │   └── Screening
│   │       └── ScreeningControllerTests.cs
│   ├── KanzWayScreening.UnitTests
│   │   └── Screening
│   │       └── GetScreeningResultQueryHandlerTests.cs
└── KanzWayScreening.sln

![WhatsApp Image 2024-10-02 at 21 49 28_293ac85f](https://github.com/user-attachments/assets/0f2f900f-dc9a-4515-8c8f-4381ee96f5e9)


## Tests 
![image](https://github.com/user-attachments/assets/d67f4eef-72c5-49b7-b292-edce5fb829a4)

![image](https://github.com/user-attachments/assets/32ec985d-3a0a-4165-9129-96ee98b8c99b)

