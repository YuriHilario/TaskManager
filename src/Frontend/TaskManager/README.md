# Task Manager - Fullstack Application

## Overview

Task Manager is a fullstack web application built with Angular 15+ on the frontend and ASP.NET Core 6 on the backend.  
The system allows users to manage their personal tasks with basic CRUD operations (Create, Read, Update, Delete).  
It features JWT-based authentication to secure API endpoints and protect routes in the frontend.

---

## Features

- User Authentication with JWT
- Task List: view all tasks with details
- Create new tasks
- Update existing tasks
- Delete tasks with confirmation
- Task properties: title, description, priority (low, medium, high), status (to do, in progress, done), and creation date
- Route protection using Angular Guards
- RESTful API adhering to best practices
- Basic error handling in frontend and backend
- Persistence using Microsoft SQL Server with Entity Framework Core

---

## Project Structure

/frontend/ # Angular 15+ project with components, services, guards, and routing
/backend/ # ASP.NET Core 6 REST API project using EF Core and JWT authentication

---

## Requirements

- Node.js >= 16.x
- Angular CLI >= 15.x
- .NET 6 SDK
- Microsoft SQL Server
- Recommended: Visual Studio Code or Visual Studio 2022

---

## Setup and Running

### Backend

1. Configure your MSSQL connection string in `appsettings.json` under `DefaultConnection`.
2. Apply migrations to create the database and tables:
   ```bash
   dotnet ef database update

#### Run the API:

dotnet run
API will be available at https://localhost:7115/api

### Frontend

1. Navigate to the frontend folder:
using cd frontend

2. Install dependencies: 
using npm install

3. Run the Angular app:
using ng serve

4. Open your browser at http://localhost:4200

### SQL
#### Create Database Script

CREATE DATABASE PasqualiDevTest;

Create TABLE Tasks (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title VARCHAR(100) NOT NULL,
    [Description] VARCHAR(255) NULL,
    [Priority] INT NOT NULL,
    [Status] INT NOT NULL,
    DateCreation DATETIME NOT NULL
);

CREATE TABLE Users (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,    
    [Email] NVARCHAR(255) NOT NULL UNIQUE,    
    [PasswordHash] VARCHAR(64) NOT NULL
);

#### Scripts SQL used for tests

SELECT * FROM Tasks;
SELECT * FROM Users;

INSERT INTO Users (Email, PasswordHash)
VALUES ('manager@dev.com', '4841a1cc40ba16f5c5bd1c3696658c1969bb9e32dccdf00aef7cd3cee4b2bf48');


### Notes

1. The application uses JWT tokens stored in localStorage for session management.

2. Angular route guards protect pages that require authentication.

3. The UI is functional using Angular Material components.

4. Error messages are displayed on failure in forms and task operations.

5. Responsiveness is basic and can be improved.

6. Data that can use for access the system (User: manager@dev.com Password: managerDev)



