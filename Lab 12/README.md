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
1. Bấm Lưu tất cả: gọi `EndEdit()` để lấy giá trị đang sửa trên grid.
2. `ValidateData` kiểm tra điểm là số và từ 0 đến 10. Có dòng sai thì báo lỗi, chưa chạm database.
3. `KetQuaDAL.SaveAll` mở transaction, gọi `sp_KetQua_Save` cho từng dòng, xong hết mới Commit. Có lỗi thì Rollback.

Các test case xem trong `TestCases.md`.

## Đẩy lên GitHub
```
git init
git add .
git commit -m "Lab 12 - Nhap diem theo lop"
git branch -M main
git remote add origin <link-repo-cua-ban>
git push -u origin main
```
