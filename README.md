# 🧠 TaskManager API

TaskManager is a RESTful API built with ASP.NET Core 8.0. It helps you manage tasks with features like create, update, delete, and list. The project uses clean architecture, DTOs, error handling, and unit tests.

---

## 📌 Overview

This project allows users to manage tasks using a structured and clean backend. It includes layers like Controllers, Services, Repositories, and Data, and it uses PostgreSQL as the database.

---

## 🛠️ Technologies Used

| Layer            | Technology                      |
|------------------|----------------------------------|
| Backend API      | ASP.NET Core 8.0                |
| ORM              | Entity Framework Core           |
| Database         | PostgreSQL                      |
| Tests            | xUnit                           |
| Documentation    | Swagger                         |
| Error Handling   | Global Exception Middleware     |
| Frontend         | Reserved folder (`Frontend/`)   |

---

## 📁 Project Structure

TaskManager/
│
├── src/
│ ├── API/ # Main API project
│ │ ├── Controllers/ # Endpoints
│ │ ├── DTOs/ # Data Transfer Objects
│ │ ├── Enums/ # Priority and Status enums
│ │ ├── Exception/ # Custom exceptions
│ │ ├── Middleware/ # Error handler
│ │ ├── Models/ # Entities
│ │ ├── Repositories/ # Data access
│ │ ├── Services/ # Business logic
│ │ ├── Data/ # DbContext
│ │ └── Utils/ # (Reserved for helpers)
│ │
│ ├── Tests/ # Unit tests with xUnit
│ └── Frontend/ # Frontend project



---

## 🔗 API Endpoints

| Method | Route                | Description                 |
|--------|----------------------|-----------------------------|
| GET    | /api/TaskItem        | Get all tasks               |
| GET    | /api/TaskItem/{id}   | Get a task by ID            |
| POST   | /api/TaskItem        | Create a new task           |
| PUT    | /api/TaskItem/{id}   | Update an existing task     |
| DELETE | /api/TaskItem/{id}   | Delete a task               |

---

## ✅ Requirements & Running the Project

### 📦 Requirements
- [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- PostgreSQL
- Visual Studio or Visual Studio Code

### ⚙️ Database Configuration

Update the connection string in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=ep-lively-tree-a5klh19d-pooler.us-east-2.aws.neon.tech;Port=5432;Database=TaskManager;Username=TaskManager_owner;Password=npg_dU90TWfuXFBQ"
}

#### SCRIPT for the Create the database:

CREATE TABLE Tasks ( 
    id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    title VARCHAR(100) NOT NULL,
    description VARCHAR(255),
    priority INT NOT NULL,
    status INT NOT NULL,
    datecreation TIMESTAMP NOT NULL
);

CREATE TABLE Users (
    id SERIAL PRIMARY KEY,    
    email VARCHAR(255) NOT NULL UNIQUE,    
    passwordHash VARCHAR(64) NOT NULL
);

-- Queries
SELECT * FROM Tasks;
SELECT * FROM Users;

-- Insert Data for authentication
INSERT INTO users (Email, PasswordHash)
VALUES ('manager@dev.com', '4841a1cc40ba16f5c5bd1c3696658c1969bb9e32dccdf00aef7cd3cee4b2bf48');

#### Run the API:
cd src/API
dotnet run


#### Run Unit Tests:
cd src/Tests
dotnet test


Authentication (To-Do)
The project is ready to support JWT authentication using roles and claims. You can add it with Microsoft.AspNetCore.Authentication.JwtBearer.

