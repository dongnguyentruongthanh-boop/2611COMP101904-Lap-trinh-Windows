# ỨNG DỤNG VẼ ĐƠN GIẢN - SIMPLE PAINT (GDI+)

## 1. Thông tin bài thực hành
- **Học phần:** COMP1019 - Lập trình trên Windows (Buổi 8 - Lab 08)
- **Giảng viên hướng dẫn:** ThS. Lê Thanh Thoại
- **Đề tài:** Xây dựng ứng dụng Paint đơn giản bằng WinForms và GDI+
- **Tên project:** `COMP1019_Lab08_SimplePaint`
- **Công nghệ sử dụng:** C# WinForms, .NET 8.0, GDI+ (Graphics, Pen, Brush)
- **Hạn nộp:** Tháng 10/2026

---

## 2. Mô tả chương trình
Ứng dụng SimplePaint cho phép người dùng vẽ đồ họa tương tác trực tiếp trên vùng Canvas bằng chuột, sử dụng thư viện đồ họa **GDI+** trong .NET:
- **Các chế độ vẽ đa dạng:** Hỗ trợ vẽ tự do (Pen), vẽ đoạn thẳng (Line), hình chữ nhật (Rectangle) và hình elip (Ellipse)[cite: 17].
- **Tùy biến nét vẽ:** Dễ dàng thay đổi màu sắc thông qua `ColorDialog` và tùy chỉnh kích thước nét vẽ từ 1 đến 20 pixel qua `NumericUpDown`[cite: 17].
- **Cơ chế lưu trữ và vẽ lại bền vững:** Toàn bộ nét vẽ được đóng gói thành các đối tượng dữ liệu và lưu vào danh sách (`List<DrawItem>`). Hình vẽ được kết xuất thông qua sự kiện `Paint` của Canvas, đảm bảo không bị mất hình khi Form bị che khuất, thu nhỏ hoặc thay đổi kích thước (Resize).
- **Thao tác chỉnh sửa:** Hỗ trợ hoàn tác nét vẽ gần nhất (Undo) và xóa toàn bộ vùng vẽ (Clear)[cite: 17].
- **Theo dõi trạng thái:** Hiển thị tọa độ con trỏ chuột thời gian thực tại chân trang (Status Label)[cite: 17].
- **Tính năng mở rộng (Nâng cao):** Xuất bản vẽ ra file hình ảnh PNG, mở ảnh nền và hỗ trợ phím tắt `Ctrl + Z` tiện lợi.

---

## 3. Giao diện và các Control sử dụng

| Nhóm chức năng | Loại Control | Tên Control (`Name`) | Chức năng / Mô tả chi tiết |
| :--- | :--- | :--- | :--- |
| **Công cụ vẽ** | ComboBox | `cboMode` | Lựa chọn chế độ vẽ: `Pen`, `Line`, `Rectangle`, `Ellipse`[cite: 17] |
| | NumericUpDown | `nudWidth` | Điều chỉnh độ dày nét vẽ (giá trị từ 1 đến 20, mặc định: 2)[cite: 17] |
| | Button | `btnColor` | Mở hộp thoại `ColorDialog` để chọn màu cọ vẽ[cite: 17] |
| **Thao tác** | Button | `btnUndo` | Hoàn tác / Xóa nét vẽ gần nhất (`Ctrl + Z`) |
| | Button | `btnClear` | Xóa sạch toàn bộ nét vẽ trên bề mặt Canvas[cite: 17] |
| **Vùng vẽ & Trạng thái** | Panel / CustomPanel | `canvas` | Vùng vẽ chính (nền trắng, bật chế độ DoubleBuffered chống nháy)[cite: 17] |
| | Label / StatusLabel | `lblStatus` | Hiển thị tọa độ chuột hiện tại (`X: ..., Y: ...`)[cite: 17] |

---

## 4. Hướng dẫn thực hiện chương trình
1/ Giao diện

<img width="837" height="642" alt="Giao diện" src="https://github.com/user-attachments/assets/abf1dac3-e765-465d-ba7c-36fa49c6f1c9" />

2/ Pen

<img width="838" height="640" alt="Chế độ pen" src="https://github.com/user-attachments/assets/15c59672-79f1-41ee-aed4-fd423a8c662e" />

3/ Line

<img width="837" height="636" alt="Chế độ line" src="https://github.com/user-attachments/assets/db90f38f-432b-4ed8-b576-7ea2efcb4a60" />

4/ Rectangle
<img width="840" height="631" alt="Chế độ rectangle" src="https://github.com/user-attachments/assets/cd4c970c-c9d9-47db-beae-4f8dcd8234c8" />

5/ Circle

 <img width="838" height="645" alt="Chế độ circle" src="https://github.com/user-attachments/assets/afdf1a97-b69f-4a6b-ba23-30549bdbb6ad" />




