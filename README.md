# SaleApp_SlimCare_dotnet_react (.NET 8 + React)

## 1. Introduction

**SlimCare** is a rewritten version of an old sales web application (originally built with Java Servlet), now implemented using **.NET 8** and **React**, following a clean **3-layer architecture**.

### Project Objectives:
- Apply a proper 3-layer architecture in ASP.NET Core.
- Build a RESTful API to communicate with the React frontend.
- Fully implement core features: product management, category management, order handling, user management, shopping cart, and payment integration.

---

## 2. Project Architecture

- **SlimcareApp**: API layer — handles HTTP requests and responses.
- **SlimcareWeb.Service**: Business logic layer — processes application logic, calls DataAccess, and returns results to the API.
- **SlimcareWeb.DataAccess**: Data access layer — interacts with the database using Entity Framework Core and Repository Pattern.

---

## 3. Technologies Used

### Backend
- **.NET 8**, **Entity Framework Core**, **SQL Server**
- **RESTful API** design for React frontend integration
- **Repository Pattern**, **Dependency Injection**
- **JWT Authentication** for secure login and role-based access
- **VNPAY Integration** for online payment processing
- **BCrypt.Net** for password hashing

### Frontend
- **React 18**
- **TailWind** and **React Hooks** for responsive UI and component management

### Version Control
- **Git** + **GitHub**
