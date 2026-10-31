# COMP1019 - BUỔI 9 - LAB 09 **Thiết kế và in thẻ sinh viên bằng WinForms**

---

## 1. Mục tiêu
- Sử dụng `PictureBox` và `OpenFileDialog` để chọn, hiển thị ảnh đại diện[cite: 4].
- Vẽ preview thẻ sinh viên bằng `Panel` và `GDI+`[cite: 4].
- Sử dụng `PrintDocument` và `PrintPreviewDialog` để xem trước và in thẻ[cite: 4].
- Kiểm tra dữ liệu đầu vào và kiểm thử bản in[cite: 4].
- Rèn luyện cách tổ chức code WinForms rõ ràng, dễ đọc[cite: 4].

---

## 2. Mô tả bài toán
Xây dựng ứng dụng Windows Forms cho phép nhập thông tin sinh viên, chọn ảnh đại diện, hiển thị bản xem trước của thẻ sinh viên và in thẻ sinh viên[cite: 4]. 

*Lưu ý: Ứng dụng không yêu cầu kết nối cơ sở dữ liệu ở buổi này. Dữ liệu được nhập trực tiếp trên Form[cite: 4].*

---

## 3. Yêu cầu giao diện & Chức năng

### 3.1 Giao diện (Form chính: `FrmStudentCard`)
Chia thành 2 vùng chính: **vùng nhập liệu (bên trái)** và **vùng xem trước thẻ (bên phải)**[cite: 4].

| Nhóm control | Control gợi ý | Yêu cầu |
| :--- | :--- | :--- |
| **Thông tin sinh viên** | `TextBox`, `ComboBox`, `DateTimePicker` | Nhập mã, họ tên, lớp, khoa, khóa học, ngày sinh, giới tính[cite: 4]. |
| **Ảnh đại diện** | `PictureBox`, `Button`, `OpenFileDialog` | Chọn ảnh JPG, PNG, BMP; ảnh hiển thị không méo[cite: 4]. |
| **Preview thẻ** | `Panel` | Vẽ thẻ sinh viên bằng GDI+ trong `Paint` event[cite: 4]. |
| **In ấn** | `PrintDocument`, `PrintPreviewDialog`, `PrintDialog` | Có nút xem trước khi in và nút in[cite: 4]. |
| **Điều khiển** | `Button` | Chọn ảnh, làm mới, xem trước in, in, thoát[cite: 4]. |

### 3.2 Yêu cầu chức năng
- **Chọn ảnh (F1):** Mở `OpenFileDialog` chọn file ảnh (JPG, JPEG, PNG, BMP), hiển thị trong `PictureBox` chế độ Zoom[cite: 5].
- **Preview thẻ (F2):** Panel preview tự động vẽ lại bằng GDI+ khi nhập hoặc thay đổi dữ liệu[cite: 5].
- **Validation (F3):** Không cho phép preview/in nếu thiếu mã sinh viên, họ tên hoặc ảnh[cite: 5].
- **Print Preview (F4):** Mở `PrintPreviewDialog` để xem trước khi in[cite: 5].
- **Print (F5):** Mở `PrintDialog` và tiến hành in qua `PrintDocument`[cite: 5].
- **Làm mới (F6):** Xóa dữ liệu nhập, xóa ảnh, đưa Form về trạng thái ban đầu[cite: 5].

---

## 4. Hướng dẫn cài đặt & Chạy chương trình

1/ Giao diện 

<img width="965" height="543" alt="Giao diện" src="https://github.com/user-attachments/assets/85e7378e-150e-4f12-81ea-5172b19447c6" />

2/ Sau khi điền đầy đủ thông tin sẽ cập nhật tức thì

<img width="957" height="542" alt="Thông tin đầy đủ" src="https://github.com/user-attachments/assets/5f04437d-80cd-4684-90b7-f4d6022b9667" />

3/ Thiếu mã sinh viên

<img width="937" height="531" alt="Thiếu msv" src="https://github.com/user-attachments/assets/234629a4-4f4d-4092-86de-25f17a372542" />

4/ Thiếu tên
<img width="962" height="538" alt="Thiếu tên" src="https://github.com/user-attachments/assets/b90fcc8e-01bd-4d09-b1dd-4f956efc21de" />

5/ Bản xem trước khi in

<img width="1293" height="472" alt="Bản xem trước in" src="https://github.com/user-attachments/assets/5f937eca-1827-4f4a-ac7d-989f48cbaaf8" />

6/ In ảnh

<img width="960" height="543" alt="In ảnh" src="https://github.com/user-attachments/assets/67e4ff18-3cda-4c34-9b34-8efbd1cdd88d" />





