\# SteppaWeb



A full-stack ASP.NET Core MVC web application for managing inventory for STEPPA, a campus sock business.



\## Features

\- Full CRUD (Create, Read, Update, Delete) for product inventory via web pages

\- Built with ASP.NET Core MVC and Entity Framework Core

\- SQLite database with EF Core migrations

\- A REST API (`ProductsApiController`) exposing product data as JSON

\- Clean separation of Models, Views, and Controllers (MVC pattern)



\## Tech Stack

\- C# / ASP.NET Core MVC

\- Entity Framework Core (Sqlite provider)

\- Razor Views

\- Git / GitHub



\## Status

Learning project — built step by step while studying C#, SQL, and ASP.NET Core fundamentals, moving from a console app (see \[STEPPA](https://github.com/Kuhundac/STEPPA)) to a full web application.



\## Running Locally

1\. Clone the repo

2\. Run `dotnet ef database update` to create the local SQLite database

3\. Run `dotnet run` from the `SteppaWeb/SteppaWeb` folder

4\. Visit `https://localhost:\[port]/Home/Products`

