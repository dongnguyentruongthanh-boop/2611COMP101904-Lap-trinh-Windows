# StudentReportDemo - Lab 13: Báo cáo sinh viên bằng LINQ

Form báo cáo danh sách sinh viên theo lớp: lọc theo lớp, kết quả, từ khóa; sắp xếp, thống kê bằng LINQ; xuất file CSV hoặc TXT.

## Chuẩn bị
- Windows, Visual Studio 2022 (workload .NET desktop) hoặc .NET 8 SDK
- Không cần cài thư viện nào thêm, không dùng database (dữ liệu mẫu tạo trong code)

## Cách chạy
- Visual Studio: mở `StudentReportDemo.csproj`, bấm F5.
- Terminal: vào thư mục project, chạy `dotnet run`.

## Cấu trúc
```
StudentReportDemo
├── Models
│   └── SinhVien.cs
├── Forms
│   ├── FrmBaoCaoSinhVien.cs
│   └── FrmBaoCaoSinhVien.Designer.cs
└── Program.cs
```

## Chức năng
## Giao diện

<img width="841" height="547" alt="Screenshot 2026-11-01 203631" src="https://github.com/user-attachments/assets/7ab4cdca-3560-4ca6-99f5-159476cccff2" />

## Thống kê tất cả

<img width="841" height="547" alt="Screenshot 2026-11-01 203648" src="https://github.com/user-attachments/assets/8ee6afcb-b26b-482b-8411-f90176762b69" />

## Tìm kiếm sinh viên đạt

<img width="842" height="541" alt="Screenshot 2026-11-01 203701" src="https://github.com/user-attachments/assets/76b62c53-2b77-4989-9d56-6c13b9afb695" />

## Tìm kiếm sinh viên không đạt

<img width="842" height="546" alt="Screenshot 2026-11-01 203709" src="https://github.com/user-attachments/assets/b217bdcf-63db-4aed-b38a-479683e1753e" />

## Tìm theo mã sinh viên
<img width="838" height="545" alt="Screenshot 2026-11-01 203750" src="https://github.com/user-attachments/assets/a99e0d47-b975-4aab-928d-f5440644d367" />
## Không tìm thấy dữ liệu

<img width="847" height="548" alt="Screenshot 2026-11-01 203832" src="https://github.com/user-attachments/assets/475b7738-a0eb-4bfa-b98d-7a82faeaa031" />

## Tìm kiếm theo tên

<img width="841" height="545" alt="Screenshot 2026-11-01 204025" src="https://github.com/user-attachments/assets/16785363-91b3-44c8-b3b1-e8d46276bd15" />




