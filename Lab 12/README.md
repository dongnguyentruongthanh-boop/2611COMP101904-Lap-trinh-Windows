# QLSinhVienLab12 - Lab 12: Data Binding, Stored Procedure và Transaction

Form nhập điểm theo lớp: chọn lớp, môn học, tải danh sách sinh viên, nhập điểm và lưu tất cả bằng transaction.

## Chuẩn bị
- Visual Studio 2022, .NET 8
- SQL Server và SSMS
- Package `Microsoft.Data.SqlClient` đã có trong csproj (cần có mạng ở lần build đầu)

## Cách chạy
1. Mở SSMS, chạy file `Database/QLSinhVienLab12.sql` (tạo database, bảng, dữ liệu mẫu, 4 stored procedure).
2. Mở `QLSinhVienLab12.csproj` bằng Visual Studio, bấm F5.

Connection string nằm trong `DAL/Database.cs`:
```
Data Source=.;Initial Catalog=QLSinhVienLab12;Integrated Security=True;TrustServerCertificate=True
```
Nếu dùng SQL Server Express thì đổi thành `Data Source=.\SQLEXPRESS`.

## Cấu trúc
```
QLSinhVienLab12
├── Forms
│   ├── FrmNhapDiemTheoLop.cs
│   └── FrmNhapDiemTheoLop.Designer.cs
├── DAL
│   ├── Database.cs        (connection string)
│   └── KetQuaDAL.cs       (gọi stored procedure, transaction)
├── Database
│   └── QLSinhVienLab12.sql
└── Program.cs
```

## Stored procedure
- sp_Lop_GetAll
- sp_MonHoc_GetAll
- sp_KetQua_GetByLopMon (sinh viên chưa có điểm thì hiện điểm 0)
- sp_KetQua_Save (đã có điểm thì UPDATE, chưa có thì INSERT)

## Cách hoạt động của phần lưu
## Giao diện
<img width="757" height="557" alt="Screenshot 2026-11-01 202156" src="https://github.com/user-attachments/assets/51855c8b-cbb7-402b-906f-0e466cdfab99" />

## Nhập điểm sai
<img width="751" height="557" alt="Screenshot 2026-11-01 202847" src="https://github.com/user-attachments/assets/aaefe1b8-647f-4171-974e-c48084392dcf" />

## Lưu thành công
<img width="777" height="570" alt="Screenshot 2026-11-01 202214" src="https://github.com/user-attachments/assets/e98bdd7f-0dd3-47fd-8c35-ccd342650052" />


## Lưu đồng thời trên sql
<img width="1660" height="416" alt="Screenshot 2026-11-01 202656" src="https://github.com/user-attachments/assets/7144ae73-f750-4f17-8d44-761957e1cd92" />



