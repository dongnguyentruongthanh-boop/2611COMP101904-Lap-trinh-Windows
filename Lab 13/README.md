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
| Chức năng | Cách làm |
|-----------|----------|
| Load lớp và kết quả vào ComboBox | `LoadComboBox`: Select + Distinct + OrderBy |
| Xem báo cáo | `XemBaoCao`: Where (lớp, kết quả, từ khóa), OrderByDescending theo điểm, ThenBy họ tên, Select |
| Thống kê trên label | `CapNhatThongKe`: Count, Average |
| Thống kê theo lớp | `btnThongKe_Click`: GroupBy, Count, Average |
| Xuất file | `XuatFile`: SaveFileDialog, StringBuilder, File.WriteAllText, có try-catch |

Báo cáo tự cập nhật khi đổi lớp, đổi kết quả hoặc gõ từ khóa. Nếu không có dữ liệu thì label báo rõ, bấm nút Xem báo cáo thì hiện thêm hộp thoại.

Các test case xem trong `TestCases.md`.

## Đẩy lên GitHub
```
git init
git add .
git commit -m "Lab 13 - Bao cao sinh vien bang LINQ"
git branch -M main
git remote add origin <link-repo-cua-ban>
git push -u origin main
```
