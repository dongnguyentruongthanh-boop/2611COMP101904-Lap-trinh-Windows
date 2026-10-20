# QUẢN LÝ SẢN PHẨM - PRODUCT MANAGER

## 1. Thông tin bài thực hành
- **Học phần:** COMP1019 - Lập trình trên Windows (Lab Buổi 5)
- **Đề tài:** Xây dựng ứng dụng Windows Forms App bằng C# quản lý sản phẩm sử dụng DataGridView và BindingSource
- **Hạn nộp:** Tháng 10/2026

---

## 2. Mô tả chương trình
Ứng dụng ProductManager được thiết kế nhằm hỗ trợ cửa hàng quản lý danh sách sản phẩm trực tiếp trong bộ nhớ, không cần sử dụng cơ sở dữ liệu phức tạp.
Chương trình cung cấp các tính năng chính:
- Khởi tạo và hiển thị danh sách sản phẩm mẫu ngay khi mở form.
- Thêm, sửa, xóa thông tin sản phẩm và cập nhật thời gian thực qua `BindingList` và `BindingSource`.
- Kiểm tra tính hợp lệ của dữ liệu đầu vào bằng `ErrorProvider` (không để trống mã/tên, đơn giá > 0, số lượng không âm, ngày nhập không lớn hơn hiện tại và không trùng mã sản phẩm).
- Tìm kiếm nhanh gần đúng theo mã hoặc tên sản phẩm không phân biệt chữ hoa/thường.
- Hỗ trợ chọn ảnh minh họa sản phẩm bằng `OpenFileDialog` với chế độ hiển thị `Zoom`.
- MenuStrip, ToolStrip, StatusStrip và ContextMenuStrip hỗ trợ thao tác nhanh, xem chi tiết và xác nhận thoát ứng dụng.

---

## 3. Giao diện và các Control sử dụng
Giao diện bao gồm MenuStrip, ToolStrip, GroupBox nhập liệu, khu vực tìm kiếm, DataGridView và StatusStrip ở chân trang:

| Nhóm thông tin | Control | Tên Control (Name) | Chức năng / Ghi chú |
| :--- | :--- | :--- | :--- |
| **Thông tin sản phẩm** | TextBox | `txtMaSP` | Mã sản phẩm (duy nhất, khóa khi sửa) |
| | TextBox | `txtTenSP` | Tên sản phẩm |
| | ComboBox | `cboLoaiSP` | Loại sản phẩm (Điện tử, Văn phòng phẩm, Gia dụng, v.v.) |
| | NumericUpDown | `numDonGia` | Đơn giá sản phẩm (định dạng tiền tệ VNĐ) |
| | NumericUpDown | `numSoLuong` | Số lượng tồn kho |
| | DateTimePicker | `dtpNgayNhap` | Ngày nhập kho sản phẩm |
| | CheckBox | `chkConKinhDoanh` | Trạng thái kinh doanh |
| | TextBox | `txtDuongDanAnh` | Đường dẫn file ảnh |
| | Button | `btnChonAnh` | Mở hộp thoại chọn ảnh minh họa |
| | PictureBox | `picAnh` | Hiển thị ảnh sản phẩm (`SizeMode.Zoom`) |
| **Vùng thao tác** | Button | `btnThem` | Thêm mới sản phẩm |
| | Button | `btnSua` | Cập nhật thông tin sản phẩm |
| | Button | `btnXoa` | Xóa sản phẩm được chọn |
| | Button | `btnLamMoi` | Làm mới form và dữ liệu |
| **Tìm kiếm & Bảng** | TextBox | `txtTimKiem` | Nhập từ khóa tìm kiếm theo mã hoặc tên |
| | DataGridView | `dgvProducts` | Hiển thị danh sách (ReadOnly, FullRowSelect) |

---

## 4. Hướng dẫn thực hiện chương trình 
# Giao diện chính:

<img width="1069" height="690" alt="Giao Diện" src="https://github.com/user-attachments/assets/05f7b69e-414f-4717-adbd-cde8a31ede1f" />

# Menu Strip
<img width="1070" height="688" alt="Hệ thống" src="https://github.com/user-attachments/assets/d2619cfd-2fc5-4dc5-96a6-40062f01a5fa" />
<img width="1072" height="691" alt="Quản lý" src="https://github.com/user-attachments/assets/9f748b01-9896-4cba-ac13-4f3a8fd7576f" />
<img width="1069" height="688" alt="GIới thiệu" src="https://github.com/user-attachments/assets/12e3eaa0-01a2-4a25-9117-384d21005cf2" />

# Nhập dữ liệu
## Đơn giá: ( Khi sai điều kiện đơn giá <= 0 )

<img width="1070" height="686" alt="Đơn giá " src="https://github.com/user-attachments/assets/5d5c3546-57b0-4eb4-8180-fe6fb64d92b9" />

## Thiếu Mã sản phẩm và Tên sản phẩm

<img width="1069" height="686" alt="Nhập thông tin" src="https://github.com/user-attachments/assets/8b82c81c-70dc-4142-b433-96e3b9f54882" />

## Cập nhật thành công

<img width="1071" height="688" alt="Cập nhật" src="https://github.com/user-attachments/assets/2931e8d0-a593-4a26-935c-6ca508daa0b8" />

## Trùng mã sản phẩm
<img width="1069" height="693" alt="Trùng mã sản phẩm" src="https://github.com/user-attachments/assets/953ed61e-3cb1-42d8-a4fb-9a63ab365590" />

## Tìm kiếm sản phẩm và hủy tìm

<img width="1061" height="685" alt="Tìm kiếm" src="https://github.com/user-attachments/assets/758eefd7-5bb5-416d-8524-148d8a2b4705" />

<img width="1071" height="689" alt="Hủy tìm" src="https://github.com/user-attachments/assets/a8fa882a-c0a0-4f51-ad7c-d1ec235afcd5" />

## Status hiện tại và sau khi xóa

<img width="1071" height="688" alt="Status" src="https://github.com/user-attachments/assets/395987e6-d805-44da-8a6b-4a3e75e5ce2f" />


<img width="1072" height="690" alt="Status xóa" src="https://github.com/user-attachments/assets/8b0d391e-58c9-48cd-a506-c0407e29307f" />

## Thoát chương trình

<img width="1070" height="691" alt="Thoát" src="https://github.com/user-attachments/assets/0a1ca4a8-b6b2-476f-b3ee-7448f787a7ea" />

## 5. Kết quả đạt được
- Chương trình chạy ổn định trên .NET Framework 4.8, không phát sinh lỗi biên dịch.
- Tách bạch cấu trúc file rõ ràng giữa logic và giao diện (`Product.cs`, `FrmProduct.cs`, `Program.cs`), dễ đọc và dễ bảo trì.
- Các ràng buộc dữ liệu, cơ chế binding qua `BindingSource` và xử lý ngoại lệ ảnh không tồn tại hoạt động chính xác, đáp ứng tốt yêu cầu bài Lab.
