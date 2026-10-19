# BUỔI 4 - LAB 04: QUẢN LÝ SẢN PHẨM (CONSOLE APP)

Học phần: Lập trình trên Windows (COMP1019)  
Công cụ: Visual Studio, C# .NET Console Application

---

## 1. Mục tiêu và Kỹ thuật áp dụng
- **Xử lý ngoại lệ (Exception Handling):** Áp dụng `try-catch` và xây dựng các Exception tự tạo (`DuplicateProductException`, `ProductNotFoundException`) để xử lý lỗi nhập liệu và logic nghiệp vụ.
- **Event / Action:** Sử dụng `event Action<string>` để phát thông báo mỗi khi thêm hoặc xóa sản phẩm thành công.
- **Generic Repository:** Thiết kế lớp dùng chung `Repository<T> where T : IEntity` quản lý danh sách bộ nhớ (CRUD cơ bản).
- **Delegate / Func:** Sử dụng `Func<Product, bool>` để tìm kiếm và lọc sản phẩm theo điều kiện linh hoạt (tìm kiếm theo tên, lọc khoảng giá).
- **Validation:** Bắt lỗi dữ liệu nhập từ bàn phím (trống, sai định dạng số, số âm) tránh dừng chương trình đột ngột.

---

## 2. Cấu trúc Project
Project được tổ chức thành 2 file mã nguồn chính:
- `ProductManager.cs`: 
  - `IEntity`: Ràng buộc khóa định danh `Id`.
  - `Product`: Thực thể sản phẩm (Mã, Tên, Giá, Số lượng).
  - `DuplicateProductException`, `ProductNotFoundException`: Các lớp ngoại lệ tùy chỉnh.
  - `Repository<T>`: Generic class quản lý danh sách thực thể.
  - `ProductService`: Xử lý nghiệp vụ kho, kiểm tra trùng lặp và kích hoạt sự kiện.
- `Program.cs`: Quản lý giao diện dòng lệnh (Console Menu), điều hướng chức năng và bắt lỗi ngoại lệ khi người dùng tương tác.

---

## 3. Các chức năng chính
1. **Thêm sản phẩm:** Nhập mã, tên, đơn giá, số lượng (kiểm tra không trống và không trùng mã).
2. **Xuất danh sách:** Hiển thị toàn bộ thông tin sản phẩm có trong hệ thống.
3. **Tìm theo mã:** Tìm kiếm chính xác sản phẩm theo mã ID.
4. **Tìm theo tên:** Tìm kiếm sản phẩm có tên chứa từ khóa.
5. **Lọc theo khoảng giá:** Lọc danh sách theo giá tối thiểu và tối đa bằng `Func<Product, bool>`.
6. **Xóa sản phẩm:** Xóa sản phẩm theo mã và phát sự kiện thông báo.
7. **Tính tổng giá trị kho:** Tính và in tổng tiền hàng tồn kho (`Giá * Số lượng`).
0. **Thoát:** Kết thúc chương trình.

---

## 4. Hướng dẫn chạy chương trình
1/ Giao diện

<img width="977" height="515" alt="Giao diện" src="https://github.com/user-attachments/assets/96df4c4b-8f7b-42ba-b95e-98f7c606f05c" />

2/ Thêm sản phẩm

<img width="980" height="511" alt="Thêm sản phẩm" src="https://github.com/user-attachments/assets/b66e2611-1a69-4090-aed5-7c931cf6e2ea" />

3/ Tìm kiếm theo mã

<img width="977" height="510" alt="TÌm kiếm sản phẩm" src="https://github.com/user-attachments/assets/71e65c2d-be05-458f-8bb6-b29d8ac3b7ee" />

4/ Tìm kiếm theo tên

<img width="974" height="511" alt="Tìm kiếm theo tên" src="https://github.com/user-attachments/assets/5ea45bc4-abf9-4822-978c-8bfa6bffaa47" />

5/ Lọc giá trị
<img width="977" height="510" alt="Lọc theo giá trị" src="https://github.com/user-attachments/assets/51027b58-aea9-4128-b450-f61098c9798d" />

6/ Xuất sản phẩm

<img width="977" height="508" alt="Xuất sản phẩm" src="https://github.com/user-attachments/assets/2c5fab3f-4009-45f6-84e4-22f7af2f6680" />

7/ Tổng giá trị tồn kho

<img width="973" height="510" alt="Tổng giá trị tồn kho" src="https://github.com/user-attachments/assets/6cea39c0-d594-4a55-b989-83c8102b9fec" />

8/ Thoát

<img width="976" height="507" alt="Thoát chương trình" src="https://github.com/user-attachments/assets/00bbc502-210e-48a5-a612-8a7efb5c30ba" />




