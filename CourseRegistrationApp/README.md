# ỨNG DỤNG ĐĂNG KÝ KHÓA HỌC 

## 1. Thông tin bài thực hành
* **Học phần:** COMP1019 - Lập trình trên Windows (Lab Buổi 5)
* **Đề tài:** Xây dựng ứng dụng Windows Forms App bằng C# quản lý và đăng ký khóa học cơ bản
* **Hạn nộp:** 29/09/2026 

---

## 2. Mô tả chương trình
Ứng dụng **CourseRegistrationApp** được thiết kế nhằm hỗ trợ học viên thực hiện việc đăng ký các khóa học tin học ngắn hạn. 
Chương trình cung cấp các tính năng chính:
* Tự động nạp danh sách khóa học và tính toán học phí theo thời gian đăng ký.
* Kiểm tra tính hợp lệ của dữ liệu đầu vào (Validation) như: Họ tên không được để trống/chứa số, số điện thoại đúng 10 chữ số, ngày sinh hợp lệ
* Hiển thị chi tiết phiếu đăng ký thông qua hộp thoại `MessageBox` trực quan
* Cho phép làm mới form hoặc thoát chương trình có kèm hộp thoại xác nhận

---

## 3. Giao diện và các Control sử dụng
Giao diện được phân chia thành 2 nhóm thông tin chính sử dụng `GroupBox` và một vùng nút lệnh ở phía dưới:

| Nhóm thông tin | Control | Tên Control (Name) | Chức năng / Ghi chú |
| :--- | :--- | :--- | :--- |
| **Thông tin học viên** | TextBox | `txtHoTen` | Nhập họ tên học viên |
| | TextBox | `txtSoDienThoai` | Nhập số điện thoại (10 chữ số) |
| | DateTimePicker | `dtpNgaySinh` | Chọn ngày sinh của học viên |
| | CheckBox | `chkNhanEmail` | Tùy chọn nhận thông báo qua email |
| **Thông tin khóa học** | ComboBox | `cboKhoaHoc` | Lựa chọn các khóa học |
| | RadioButton | `radOnline` | Chọn hình thức học Online] |
| | RadioButton | `radOffline` | Chọn hình thức học trực tiếp (Offline) |
| | NumericUpDown | `numSoThang` | Chọn số tháng đăng ký (từ 1 đến 12)|
| | Label | `lblTongTien` | Hiển thị tổng số tiền thanh toán[cite: 1] |
| **Vùng nút lệnh** | Button | `btnDangKy` | Xử lý kiểm tra dữ liệu và in phiếu đăng ký[ |
| | Button | `btnLamMoi` | Xóa dữ liệu cũ, đưa form về trạng thái ban đầu] |
| | Button | `btnThoat` | Hiển thị hộp thoại xác nhận và thoát ứng dụng |

---

## 4. Danh sách các khóa học và học phí
Ứng dụng tích hợp sẵn 4 khóa học cơ bản với mức học phí tương ứng:
1. **C# WinForms cơ bản:** 800.000 VNĐ / tháng
2. **SQL Server cơ bản:** 700.000 VNĐ / tháng
3. **Web Frontend cơ bản:** 750.000 VNĐ / tháng
4. **Lập trình Python cơ bản:** 650.000 VNĐ / tháng

---

## 5. Hướng dẫn thực hiện chương trình 
# Giao diện:
<img width="822" height="417" alt="Giao diện" src="https://github.com/user-attachments/assets/27c98b09-df67-4b1e-b51f-e50dff99b9d3" />

# Nhập Họ Tên 
<img width="809" height="384" alt="nhaphoten" src="https://github.com/user-attachments/assets/aa4fc3e6-f4b8-4352-a064-73f19aa3f5a9" />

<img width="814" height="387" alt="tenchuso" src="https://github.com/user-attachments/assets/72c57860-5b19-4c29-885e-4c6ac102b881" />


# Nhập Số điện thoại

<img width="813" height="383" alt="sdt" src="https://github.com/user-attachments/assets/214e04f1-c3ed-4535-9e73-1edc2d93195a" />

<img width="815" height="376" alt="10chuso" src="https://github.com/user-attachments/assets/ed5afd15-9325-4af7-842f-a1b9dfccb99a" />
# Khóa học
<img width="813" height="388" alt="1600" src="https://github.com/user-attachments/assets/53abcde1-d217-4780-8972-5825ed74dfcd" />

<img width="815" height="389" alt="800" src="https://github.com/user-attachments/assets/9bf7137e-fa07-43c5-84a3-27a1b2b7bbf6" />

# Đăng ký thành công
<img width="815" height="386" alt="dangky" src="https://github.com/user-attachments/assets/5d67e52b-3cfa-41d7-a251-661c4f26d55d" />
# Thoát
<img width="820" height="386" alt="thoat" src="https://github.com/user-attachments/assets/5010d798-48d8-4a2f-a393-65955424408d" />

# Làm mới
<img width="822" height="417" alt="Giao diện" src="https://github.com/user-attachments/assets/5361b28c-d71c-469d-9f19-3410a7959c81" />

## 6. Kết quả đạt được
* Ứng dụng chạy ổn định, không phát sinh lỗi biên dịch.
* Giao diện trực quan, căn chỉnh ngay ngắn, đáp ứng đầy đủ tiêu chí thẩm mỹ và yêu cầu chức năng của đề bài Lab.
* Các ràng buộc dữ liệu  hoạt động chính xác, đảm bảo tính toàn vẹn của dữ liệu học viên trước khi xác nhận.

---

