# COMP1019 - Buổi 11 - Lab 11: ADO.NET và CRUD với SQL Server

Form quản lý lớp học (bảng LOP) kết nối SQL Server bằng ADO.NET (Microsoft.Data.SqlClient).

## Chuẩn bị
- Visual Studio 2022, .NET 8
- SQL Server (và SSMS)
- Package `Microsoft.Data.SqlClient` đã khai báo sẵn trong file csproj, Visual Studio sẽ tự tải khi build (cần có mạng lần đầu)

## Cách chạy
1. Mở SSMS, chạy file `EduManagerDB.sql` để tạo database và dữ liệu mẫu.
2. Mở `COMP1019_Buoi11_Lab11.csproj` bằng Visual Studio, bấm F5.

## Connection string đang dùng (máy cá nhân)
```
Data Source=.;Initial Catalog=EduManagerDB;Integrated Security=True;TrustServerCertificate=True
```
Nếu máy dùng SQL Server Express thì đổi `Data Source=.` thành `Data Source=.\SQLEXPRESS` ở đầu file `FrmLop.cs`.

## Lưu ý
- Script `EduManagerDB.sql` xóa và tạo lại database EduManagerDB. Nếu muốn giữ database của buổi 10, hãy đổi tên database trong script và trong connection string.
- Bảng LOP ở buổi 11 chỉ có MaLop và TenLop (theo đề). Nếu dùng database buổi 10 thì bảng LOP có thêm cột MaKhoa bắt buộc nên chức năng Thêm lớp sẽ báo lỗi.

## Chức năng
| Mã | Chức năng | Ghi chú |
|----|-----------|---------|
| F1 | Load danh sách lớp khi mở Form | Có cột số sinh viên |
| F2 | Click dòng đưa dữ liệu lên TextBox | Ô mã lớp bị khóa |
| F3 | Thêm | Kiểm tra rỗng và trùng mã |
| F4 | Sửa | Phải chọn lớp trước |
| F5 | Xóa | Hỏi xác nhận, không xóa lớp đang có sinh viên |
| F6 | Tìm kiếm | LIKE theo mã hoặc tên, dùng parameter |
| F7 | Làm mới | Xóa TextBox, mở khóa ô mã, load lại |
| F8 | Dùng SqlParameter cho mọi câu SQL có dữ liệu nhập | |

Các test case xem trong `TestCases.md`.

## Đẩy lên GitHub
```
git init
git add .
git commit -m "Lab 11 - CRUD lop hoc voi ADO.NET"
git branch -M main
git remote add origin <link-repo-cua-ban>
git push -u origin main
```
