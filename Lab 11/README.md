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

## Thực hiện chương trình
## Giao diện
<img width="630" height="511" alt="Giao diện" src="https://github.com/user-attachments/assets/368c4b06-2616-4bc8-931a-e004f21ad32e" />

## Trùng mã lớp
<img width="640" height="508" alt="Trùng mã lớp" src="https://github.com/user-attachments/assets/51c52a1e-3078-4818-a574-67a6c216f2b2" />

## Thêm lớp
<img width="640" height="515" alt="thêm lớp" src="https://github.com/user-attachments/assets/3e92c6f5-fc12-4b7e-96b5-1bfdd5742d2e" />

## Không thể xóa nếu lớp có sinh viên
<img width="636" height="513" alt="không thể xóa nếu lớp có sinh viên" src="https://github.com/user-attachments/assets/b6a51941-6620-4781-b792-fc1a75a5036e" />

## Tìm kiếm
<img width="641" height="517" alt="tìm kiếm" src="https://github.com/user-attachments/assets/3cdde176-a8e3-4ad9-8a03-ea41008837db" />

## Sửa thành công
<img width="626" height="503" alt="Sửa thành công" src="https://github.com/user-attachments/assets/8151361e-1f98-4640-9551-b9a493e2489b" />

## Click vào 1 dòng
<img width="628" height="502" alt="Click vào" src="https://github.com/user-attachments/assets/88bb4195-a0c9-44a9-8eb6-47e9436dc42b" />

## SQL cập nhật
<img width="1280" height="536" alt="SQL" src="https://github.com/user-attachments/assets/258e5d45-5f98-48ff-a677-cf6b94dbe46b" />
