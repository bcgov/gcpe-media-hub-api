# Gcpe.MediaHub.API

A .NET 9 Web API for managing media outlets, contacts, requests, and communications. Built with Entity Framework Core and SQLite for rapid development and deployment.

---

## 🚀 Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download)
- Git

---

### 🔧 Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/bcgov/gcpe-media-hub-api.git
   cd gcpe-media-hub-api/Gcpe.MediaHub.API
   ```
2. **Create a connection string for a SQLite database in secrets.json**
   ```
   {
    "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
     }
   },
   "AllowedHosts": "*",
   "ConnectionStrings": {
     "GcpeMediaHubAPIContext": "Data Source=GcpeMediaHubAPIContext-<Guid>.db"
    }
   } 
   ```

3. **Apply migrations & create database**
   ```bash
   dotnet ef database update
   ```

4. **Run the API**
   ```bash
   dotnet run
   ```

The API will auto-create a SQLite `.db` file and seed initial data on startup.

---

## 🔐 Authentication

This API uses **Basic Authentication**.

To access secured endpoints:

- Add a username and password in the BasicAuthenticationHandler.cs file in Services/

Include the header:
```http
Authorization: Basic YWRtaW46cGFzc3dvcmQxMjM=
```
(That's `username:password` Base64-encoded.)

---

## 📁 Project Structure

| Folder         | Purpose                               |
|----------------|----------------------------------------|
| `Controllers/` | API endpoint definitions               |
| `Models/`      | Entity and DTO definitions             |
| `Data/`        | `DbContext`, seed logic, migrations    |
| `Services/`    | Optional service layer                 |
| `Migrations/`  | EF Core migrations                     |

---

## 📦 Seeding

The following are automatically seeded on startup:

- Media types (e.g. Radio, TV, Podcast)
- Spoken & written languages
- Job titles
- Phone types
- Ministries
- Request types, statuses, and resolutions
- Example media contacts, outlets, and requests

---

## 🛠 Development Tips

- Use [DB Browser for SQLite](https://sqlitebrowser.org/) to view `.db` contents
- Delete the `.db` file to reset all data, then run:
  ```bash
  dotnet ef database update
  dotnet run
  ```
