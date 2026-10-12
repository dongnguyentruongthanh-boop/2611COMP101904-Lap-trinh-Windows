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

# Chạy chương trình

## Menu Chính

<img width="975" height="509" alt="Menu Chính" src="https://github.com/user-attachments/assets/ba84ec47-dcaa-46ee-8597-3271ad467a4b" />

## Thêm sinh viên

<img width="972" height="327" alt="Thêm sinh viên thành công" src="https://github.com/user-attachments/assets/fc56c313-b9b4-420c-a107-414283160a83" />

## Xuất danh sách

<img width="972" height="239" alt="Xuất danh sách" src="https://github.com/user-attachments/assets/722b6c75-8f61-4f86-b8f4-16eedbf9db6c" />

## Tìm sinh theo mã

<img width="982" height="228" alt="Tìm mã sinh viên" src="https://github.com/user-attachments/assets/8d35d606-2477-4e45-9f48-847466d7a9fc" />

## Tìm sinh viên theo tên

<img width="978" height="220" alt="Tìm theo tên" src="https://github.com/user-attachments/assets/674d2b7c-e517-4757-a147-246294e8e86d" />

## Sửa điểm trung bình

<img width="977" height="240" alt="Sửa điểm tb" src="https://github.com/user-attachments/assets/99cdd5f1-74f0-42a5-8405-b85b4fbacc3b" />
## Xóa Sinh viên
<img width="977" height="221" alt="Xóa sinh viên" src="https://github.com/user-attachments/assets/2ea2d2ff-0b68-4ee8-9e2d-8cde54fbbbc8" />

## Sắp xếp theo thứ tự
<img width="979" height="225" alt="sắp xếp" src="https://github.com/user-attachments/assets/06154a83-3e25-4f9c-b57b-11d89db0bc1b" />

## Lọc sinh viên 
<img width="978" height="232" alt="Lọc sinh viên" src="https://github.com/user-attachments/assets/78200f60-3c98-4ce7-a991-088dcc30cf1e" />










