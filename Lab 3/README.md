# Lab 03 - Quản lý sinh viên bằng Console (C# & OOP)

Ứng dụng Console quản lý sinh viên viết bằng ngôn ngữ **C#** áp dụng các nguyên lý Lập trình hướng đối tượng (OOP) và sử dụng LINQ để xử lý dữ liệu.

## 📋 Thông tin bài tập
- **Học phần:** COMP1019 - Lập trình trên Windows
- **Buổi học:** Buổi 3 - C# và lập trình hướng đối tượng
- **Công cụ:** Visual Studio, C# Console App

---

## 🛠️ Cấu trúc chương trình
Dự án được phân chia thành các lớp (class) rõ ràng:
- `Nguoi.cs`: Lớp cơ sở chứa thông tin chung (Họ tên, Ngày sinh).
- `SinhVien.cs`: Lớp dẫn xuất kế thừa từ `Nguoi`, quản lý thêm Mã SV, Mã lớp, Điểm TB và logic xếp loại.
- `QuanLySinhVien.cs`: Lớp nghiệp vụ quản lý danh sách `List<SinhVien>` và các chức năng CRUD, tìm kiếm, sắp xếp, lọc.
- `Program.cs`: Điều phối menu vòng lặp và xử lý tương tác với người dùng.

---

## ⚙️ Các chức năng chính
1. **Thêm sinh viên:** Nhập thông tin sinh viên mới, kiểm tra trùng mã sinh viên và ràng buộc điểm từ 0 đến 10.
2. **Xuất danh sách:** Hiển thị toàn bộ danh sách sinh viên kèm xếp loại.
3. **Tìm kiếm:** Tìm theo mã sinh viên chính xác hoặc tìm theo từ khóa họ tên.
4. **Sửa & Xóa:** Cập nhật điểm trung bình hoặc xóa sinh viên dựa theo mã.
5. **Sắp xếp & Lọc:** Sắp xếp danh sách theo điểm giảm dần và lọc ra các sinh viên đạt từ 5.0 điểm trở lên bằng LINQ.
