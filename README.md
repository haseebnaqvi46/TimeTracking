# Time Tracking Application

A small application that reads employees, projects, and time entries from a database and allows creating, updating, and deleting time entries through a separate API.

The solution contains three projects:

- `TimeTracking.App` → MVC application for reading and displaying data
- `TimeTracking.Api` → REST API used for creating, updating, and deleting time entries
- `TimeTracking.Infrastructure` → shared data access layer (entities, DbContext, configuration)

The MVC application only reads data, while the API is responsible for all database writes.

---

## How to Run

### 1. Clone the repository

```bash
git clone https://github.com/haseebnaqvi46/TimeTracking.git
```

Open the solution in Visual Studio.

### 2. Configure the Database

Update the connection string in:

**`TimeTracking.App/appsettings.json`**
```json
"ConnectionStrings": {
    "DefaultConnection": "Server=DESKTOP-OFFUL75\\MSSQLSERVER01;Database=TimeTrackingDb;Trusted_Connection=True;TrustServerCertificate=True"
}
```

Update the same connection string in:

**`TimeTracking.Api/appsettings.json`**

### 3. Run Database Migrations

Open Package Manager Console and run:

```powershell
Add-Migration InitialCreate -Project TimeTracking.Infrastructure -StartupProject TimeTracking.Api
Update-Database -Project TimeTracking.Infrastructure -StartupProject TimeTracking.Api
```

This will create the database tables.

### 4. Seed Basic Data

Insert a few employees and projects manually in the database:

**Employees**

| Id | EmployeeCode | FullName |
|----|---|---|
| 1 | EMP001 | Haseeb Naqvi |
| 2 | EMP002 | Osama Asghar |

**Projects**

| Id | ProjectCode | Name |
|----|---|---|
| 1 | PRJ001 | Internal Tool |
| 2 | PRJ002 | Customer Portal |

These are needed before creating time entries.

### 5. Run the API

Set `TimeTracking.Api` as startup project and run.

Swagger will open automatically.

Example API endpoints:

```
POST    /api/time-entries
PUT     /api/time-entries/{id}
DELETE  /api/time-entries/{id}
GET     /api/time-entries
```

### 6. Run the MVC Application

Set `TimeTracking.App` as startup project and run.

Pages available:
- Time Entries
- Weekly Summary

---

## Database Structure

Tables used:
- Employees
- Projects
- TimeEntries

Example structure:

```sql
Employees
[Id] [int] IDENTITY(1,1) NOT NULL,
[EmployeeCode] [nvarchar](450) NOT NULL,
[FullName] [nvarchar](max) NOT NULL,
[IsActive] [bit] NOT NULL

Projects
[Id] [int] IDENTITY(1,1) NOT NULL,
[ProjectCode] [nvarchar](450) NOT NULL,
[Name] [nvarchar](max) NOT NULL,
[IsActive] [bit] NOT NULL

TimeEntries
[Id] [int] IDENTITY(1,1) NOT NULL,
[EmployeeId] [int] NOT NULL,
[ProjectId] [int] NOT NULL,
[EntryDate] [datetime2](7) NOT NULL,
[Hours] [decimal](5, 2) NOT NULL,
[Notes] [nvarchar](max) NOT NULL,
[Source] [nvarchar](max) NOT NULL
```

---

## Design & Rationale

### Architecture

The solution is split into three layers:

**Infrastructure**
- Contains database entities
- Contains DbContext
- Shared by both API and MVC app

**API**
- Handles all write operations
- Contains controllers and services
- Exposes REST endpoints

**MVC Application**
- Used only for reading and displaying data
- Calls the database directly in read-only mode

This structure keeps responsibilities separate and easy to understand.

### Key Considerations

While designing the solution I focused on:
- Keeping reads and writes separated
- Making the API responsible for database changes
- Keeping the code easy to follow
- Avoiding unnecessary complexity for this size of project
- Making sure errors are logged and users get clear messages

### Alternative Approaches Considered

**1. Single project for everything**

I avoided this because it mixes reading and writing responsibilities.

**2. Calling the API from the MVC app**

Instead, the MVC app reads directly from the database since the requirement stated the database is read-only for the application.

**3. Returning EF entities directly**

Instead I used DTOs in the API to avoid serialization issues and to keep the API responses clean.

### Design Patterns Used

Some common patterns used in the project:

- **Repository-like service pattern** - Services handle data access logic instead of controllers.
- **DTO pattern** - API uses DTOs for requests and responses.
- **Dependency Injection** - Services and DbContext are injected through constructors.
- **Middleware** - A simple global exception middleware handles API errors and logs them.

### Anti-Patterns Avoided

Some things I intentionally avoided:
- Putting database logic directly in controllers
- Returning EF entities directly from APIs
- Mixing read and write responsibilities in one place
- Catching exceptions everywhere instead of using centralized handling

### Best Practices Followed

Some basic practices followed during development:
- Clear separation between projects
- Dependency injection for services
- Logging important failures
- DTOs used for API responses
- Pagination support in the GET API
- Configurable overtime threshold using appsettings

---

## Time Taken

Approximately 40+ hours, spread across several sessions including:
- project setup
- database modeling
- API development
- MVC pages
- pagination and filtering
- error handling
- documentation

---

## Future Improvements

I would improve the project in the following areas:
- Add authentication for API endpoints
- Add integration tests for API endpoints
- Implement pagination metadata in response headers
- Add retry handling for API failures
- Improve UI with filtering and pagination controls
- Add API versioning
- Add caching for frequently used queries

---

## Assumptions & Tradeoffs

Some simplifications were made to keep the project focused:
- Employees and Projects are assumed to already exist
- Basic validation is used instead of a full validation framework
- The MVC app reads directly from the database instead of calling the API
- UI is kept simple since the focus is mainly on backend structure

These choices helped keep the solution smaller and easier to understand within the given time.
