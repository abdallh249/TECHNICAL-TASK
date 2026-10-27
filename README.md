# TECHNICAL TASK

## Authentication & Authorization REST API

A RESTful API built using **ASP.NET Core (.NET 10)**, **Entity Framework Core**, **MySQL**, and **JWT Authentication**.

The project implements user registration, login, password hashing, and role-based authorization.

## Technologies Used

- C# / ASP.NET Core Web API (.NET 10)
- Entity Framework Core
- MySQL Database
- JWT Bearer Authentication
- ASP.NET Core Identity PasswordHasher
- Swagger UI
- Postman Integration Testing

## API Endpoints

| Method | Endpoint | Authorization | Response |
|---|---|---|---|
| POST | `/api/auth/register` | Public | 201 / 400 |
| POST | `/api/auth/login` | Public | 200 / 401 |
| GET | `/api/profile` | Authenticated | 200 / 401 |
| GET | `/api/user` | User / Admin | 200 / 401 / 403 |
| GET | `/api/admin` | Admin Only | 200 / 401 / 403 |

## Features

### User Registration
- Register new users.
- Validate user information.
- Prevent duplicate email addresses.
- Hash passwords before saving.
- Assign the default `User` role.

### User Login
- Authenticate users using email and password.
- Verify hashed passwords.
- Generate signed JWT access tokens.

### Authorization
- Protect endpoints using `[Authorize]`.
- Support `User` and `Admin` roles.
- Restrict administrative endpoints to Admin users.

## Database

Database: `uth`

Main entity: `User`

| Property | Type |
|---|---|
| ID | int |
| FullName | string |
| Email | string |
| Password | string (hashed) |
| role | string |

## Getting Started

### 1. Restore dependencies

```bash
dotnet restore
```

### 2. Configure the application

Configure the MySQL connection string and JWT settings. Store database passwords and JWT signing keys securely using .NET User Secrets.

### 3. Apply Database Migrations

```bash
dotnet ef database update
```

**Warning:** This operation may change the database schema. Review migrations before applying them to an existing database.

### 4. Run the Application

```bash
dotnet run
```

### 5. Open Swagger

For the example local configuration:

```text
http://localhost:5069/swagger
```

Use the actual URL shown in the terminal.

## Testing

Postman integration tests cover:

- User registration
- Successful login and JWT generation
- Invalid login credentials
- Authenticated profile access
- Unauthorized access (401)
- Normal user access (200)
- Admin role restriction (403)
- Authorized Admin access (200)

## Security

Passwords are stored using ASP.NET Core PasswordHasher, not in plaintext.

JWT tokens are validated using their signature, issuer, audience, and expiration time.

Public registration never grants the Admin role. Administrative roles must be assigned through a trusted process.

## Project Status

Authentication, JWT integration, role-based authorization, database persistence, and API testing.
