# EmployeeManagementSystemWeb

A simple **.NET Core MVC Application** with SQL Server database.

---

## 🚀 Getting Started

Follow the steps below to set up and run the application locally.

### 1️⃣ Clone the repository

```bash
git clone https://github.com/hirtikmalvi/EmployeeManagementSystemWeb.git
cd EmployeeManagementSystemWeb
```

### 2️⃣ Open the solution

Open the `.sln` file in **Visual Studio** (or Visual Studio Code with C# extension).

### 3️⃣ Restore dependencies

Run the following command (or let Visual Studio restore automatically):

```bash
dotnet restore
```

### 4️⃣ Database Setup

- Make sure **SQL Server** is installed and running on your machine.  
- Update the connection string inside `appsettings.json` with your SQL Server instance details:

```json
"ConnectionStrings": {
  "DbConnection": "Server=YOUR_DB_SERVER;Database=EmployeeDB;Trusted_Connection=True;TrustServerCertificate=True"
}
```

- Run EF Core migrations (if available) or manually create the database.

```bash
dotnet ef database update
```

### 5️⃣ Run the Application

Use Visual Studio or the command line:

```bash
dotnet run
```

By default, the application will be available at:
<br>
👉 `https://localhost:7120`  
👉 `http://localhost:5116`

---

