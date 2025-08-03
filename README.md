# SaleApp_SlimCare_dotnet_react (.NET 8 + React)

## 1. Giới thiệu

Dự án Slimcare là phiên bản viết lại của web bán hàng cũ (Java Servlet) bằng .NET 8 + React theo kiến trúc 3 tầng (3-layer architecture).  

Mục tiêu của dự án:
- Áp dụng kiến trúc 3-layer chuẩn trong .NET Core.  
- Xây dựng API chuẩn RESTful để frontend React kết nối.  
- Hoàn thiện đầy đủ các chức năng: quản lý sản phẩm, danh mục, đơn hàng, người dùng, giỏ hàng và thanh toán.  

---

## 2. Kiến trúc dự án
- SlimcareApp: Tầng API, xử lý HTTP request/response.  
- SlimcareWeb.Service: Tầng nghiệp vụ (business logic), gọi DataAccess và trả kết quả cho API.  
- SlimcareWeb.DataAccess: Tầng kết nối cơ sở dữ liệu (Entity Framework Core, Repository Pattern).  

---

## 3. Công nghệ sử dụng
- Backend: .NET 8, Entity Framework Core, SQL Server  
- Frontend: React 18 (kết nối qua API)  
- Quản lý phiên bản: Git + GitHub  
