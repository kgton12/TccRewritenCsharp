# 📚 TccRewritenCsharp

## 🌟 Project Overview

The **TccRewritenCsharp** project is a rewrite of a TCC (Course Completion Work) project in C#. It is structured as a multi-project solution that includes various subprojects to form a complete application. The main goal is to provide a robust and scalable API for managing:

- 🛒 Orders
- 📦 Products
- 🏷️ Categories
- 👤 Users
- 🧾 Order Items

---

## 🏗️ Project Structure

Here is the structure of the project:

- **📂 TccRewritenCsharp.sln**: The main solution file that groups all the projects.
- **🚀 TccRewritenCsharp.API**: The main API project.
- **📝 TccRewritenCsharp.Application**: Contains the use cases of the application.
- **🔗 TccRewritenCsharp.Communication**: Contains request and response classes.
- **⚠️ TccRewritenCsharp.Exceptions**: Contains custom exceptions.
- **💾 TccRewritenCsharp.Infrastructure**: Manages data access and external services.
- **🧪 TccRewritenCsharp.Test**: Contains unit and integration tests.

---

## ✨ Features

### 🔧 **TccRewritenCsharp.API**

Handles HTTP requests and responses through API controllers:

- **📄 Controllers**:
  - 🛒 `OrdersController`: Manages orders.
  - 📦 `ProductsController`: Manages products.
  - 🏷️ `CategoriesController`: Manages categories.
  - 👤 `UsersController`: Manages users.
  - 🧾 `OrderItemsController`: Manages order items.
- **⚙️ Configuration**: Setup in `Program.cs`, including routing, Swagger, and environment settings.

### 🛠️ **TccRewritenCsharp.Application**

Implements business logic operations:

- **📚 Use Cases**:
  - 🛒 Orders
  - 📦 Products
  - 🏷️ Categories
  - 👤 Users
  - 🧾 Order Items
- **🔍 Utilities**: Common validation and helper operations.

### 🔗 **TccRewritenCsharp.Communication**

Facilitates API-client communication:

- **📩 Requests**:
  - `RequestOrderJson`, `RequestProductJson`, `RequestCategoryJson`, etc.
- **📤 Responses**:
  - `ResponseOrderJson`, `ResponseProductJson`, `ResponseCategoryJson`, etc.

### ⚠️ **TccRewritenCsharp.Exceptions**

Defines custom exceptions for better error handling.

### 💾 **TccRewritenCsharp.Infrastructure**

Manages data access and external services:

- **📊 Entities**: Models like `Order`, `Product`, `Category`, `User`, and `OrderItem`.
- **🛢️ DbContext**: `TccRewritenCsharpDbContext` manages database operations.
- **🛠️ Configuration**: Database connection strings and settings.
- **📑 Enums**: Constants like `ServiceEnvironment` and `Status`.

### 🧪 **TccRewritenCsharp.Test**

Ensures application reliability:

- **✅ Test Cases**: Covers controllers and use cases.
  - `OrderTest`, `ProductTest`, `CategoryTest`, `UserTest`, `OrderItemTest`.

---

## 📦 Libraries Used

- `Microsoft.EntityFrameworkCore` 🗃️: Database access.
- `Microsoft.EntityFrameworkCore.Design` 🎨: Design-time tools.
- `Microsoft.EntityFrameworkCore.InMemory` 🧪: In-memory database for testing.
- `Microsoft.EntityFrameworkCore.Sqlite` 📀: SQLite provider.
- `Swashbuckle.AspNetCore` 🐍: Swagger documentation.
- `Bogus` 🎲: Fake data generation.
- `FluentAssertions` ✍️: Readable assertions for tests.
- `xUnit` 🧪: Testing framework.

---

## 🚀 How to Run

1. **Clone the repository**:
   ```bash
   git clone <repository-url>
   ```

2. **Open the solution in Visual Studio**.

3. **Build the solution** to restore dependencies and compile the projects.

4. **Run the API project** (`TccRewritenCsharp.API`) to start the application.

5. **Interact with the API** using:
   - Swagger (for documentation and testing).
   - Any API client (e.g., Postman).

---

## 💡 Summary

This project provides a scalable and clean architecture solution for managing orders, products, categories, users, and order items. Designed for maintainability and robustness, it serves as a solid foundation for API-based applications. 🚀
