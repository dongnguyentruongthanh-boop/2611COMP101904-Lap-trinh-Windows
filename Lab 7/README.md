# QUẢN LÝ CỬA HÀNG MINI - SHOP MANAGER MINI

## 1. Thông tin bài thực hành
- **Học phần:** COMP1019 - Lập trình trên Windows (Lab Buổi 7)
- **Chủ đề:** SDI, MDI và ứng dụng nhiều Form trong C# WinForms
- **Đề tài:** Xây dựng ứng dụng Windows Forms đa cửa sổ ShopManagerMini quản lý cửa hàng mini
- **Công nghệ:** C# WinForms, .NET, lưu trữ dữ liệu trong bộ nhớ (In-memory List/BindingList)
- **Hạn nộp:** Tháng 10/2026

---

## 2. Mô tả chương trình
Ứng dụng **ShopManagerMini** được xây dựng nhằm mô phỏng hệ thống quản lý bán hàng nhiều phân hệ (đa Form) cho một cửa hàng tiện lợi mini, sử dụng kiến trúc giao diện **MDI (Multiple Document Interface)**:
- **Xác thực người dùng:** Kiểm tra tài khoản đăng nhập mẫu từ `FrmLogin`, truyền thông tin định danh và vai trò sang Form chính, trả về `DialogResult.OK` khi đăng nhập thành công.
- **Kiến trúc MDI Parent - Child:** `FrmMain` đóng vai trò cửa sổ cha (`IsMdiContainer = true`) tích hợp `MenuStrip` và `StatusStrip`. Các màn hình nghiệp vụ con mở gọn bên trong Form cha, không tách thành cửa sổ rời và kích hoạt lại Form cũ nếu đã mở (chống mở trùng lặp).
- **Phân hệ Quản lý sản phẩm (`FrmProduct`):** Quản lý danh sách sản phẩm trong bộ nhớ, hiển thị bảng qua `DataGridView`, hỗ trợ đầy đủ thao tác CRUD (Thêm, Sửa, Xóa, Làm mới) và tìm kiếm nhanh.
- **Phân hệ Quản lý khách hàng (`FrmCustomer`):** Quản lý thông tin hội viên/khách hàng với thao tác nhập liệu và hiển thị bảng `DataGridView`.
- **Thông tin ứng dụng (`FrmAbout`):** Màn hình hiển thị thông tin giới thiệu phiên bản phần mềm, sinh viên thực hiện và lớp học phần.
- **Bảo toàn dữ liệu & Hộp thoại cảnh báo:** Xác thực dữ liệu đầu vào (không bỏ trống, không trùng mã, không âm giá/số lượng), hỏi xác nhận khi xóa bản ghi hoặc khi đóng/thoát ứng dụng.

---

## 3. Giao diện và các Form sử dụng

### 3.1. Danh sách Form trong hệ thống
| Form | Vai trò | Yêu cầu nghiệp vụ chính |
| :--- | :--- | :--- |
| `FrmLogin` | Đăng nhập hệ thống | Nhập `Username`/`Password`, đối soát tài khoản mẫu, trả về `DialogResult.OK` khi hợp lệ |
| `FrmMain` | Màn hình chính (MDI Parent) | `IsMdiContainer = true`, chứa `MenuStrip`, `StatusStrip` hiển thị Họ tên, Vai trò và Đồng hồ hệ thống |
| `FrmProduct` | Quản lý sản phẩm (MDI Child) | CRUD sản phẩm trong bộ nhớ, hiển thị danh sách trên `DataGridView`, kiểm tra trùng lặp |
| `FrmCustomer` | Quản lý khách hàng (MDI Child) | Thêm mới, quản lý và hiển thị danh bạ khách hàng trên `DataGridView` |
| `FrmAbout` | Giới thiệu ứng dụng (MDI Child) | Hiển thị thông tin bản quyền ứng dụng, thông tin sinh viên và mã lớp học phần |

### 3.2. Tài khoản đăng nhập mẫu
| Username | Password | Họ tên hiển thị | Vai trò (Role) |
| :--- | :--- | :--- | :--- |
| `admin` | `123` | Quản trị viên | Admin |
| `user` | `123` | Nhân viên bán hàng | User |

### 3.3. Bảng thiết kế Control chính
| Phân hệ / Form | Loại Control | Tên Control (`Name`) | Chức năng / Ý nghĩa |
| :--- | :--- | :--- | :--- |
| **FrmLogin** | TextBox | `txtUsername` | Nhập tài khoản người dùng |
| | TextBox | `txtPassword` | Nhập mật khẩu (`PasswordChar = '*'`) |
| | Button | `btnLogin` | Xác thực đăng nhập |
| | Button | `btnExit` | Thoát chương trình |
| **FrmMain** | MenuStrip | `menuStripMain` | Chứa menu: Hệ thống, Danh mục, Trợ giúp |
| | ToolStripMenuItem | `mnuDangXuat`, `mnuThoat` | Nhóm chức năng Hệ thống |
| | ToolStripMenuItem | `mnuQLSanPham`, `mnuQLKhachHang` | Nhóm chức năng Danh mục |
| | ToolStripMenuItem | `mnuGioiThieu` | Nhóm chức năng Trợ giúp |
| | StatusStrip | `statusStripMain` | Thanh trạng thái chân trang |
| | ToolStripStatusLabel | `lblUserInfo`, `lblTime` | Hiển thị tên người dùng, vai trò đăng nhập và thời gian thực |
| **FrmProduct** | TextBox | `txtMaSP`, `txtTenSP` | Nhập mã định danh (duy nhất) và tên hàng hóa |
| | ComboBox | `cboLoaiSP` | Lựa chọn chủng loại sản phẩm |
| | NumericUpDown | `numDonGia`, `numSoLuong` | Nhập đơn giá (> 0) và số lượng tồn kho (>= 0) |
| | Button | `btnThem`, `btnSua`, `btnXoa`, `btnLamMoi` | Thực hiện các tác vụ cập nhật dữ liệu |
| | TextBox | `txtTimKiem` | Nhập từ khóa tìm kiếm theo mã hoặc tên sản phẩm |
| | DataGridView | `dgvProducts` | Hiển thị danh sách sản phẩm (`ReadOnly`, `FullRowSelect`) |
| **FrmCustomer**| TextBox | `txtMaKH`, `txtHoTen`, `txtSDT` | Nhập thông tin định danh và liên lạc khách hàng |
| | ComboBox | `cboLoaiKH` | Phân cấp hội viên (Thường, VIP, Thân thiết) |
| | Button | `btnThemKH` | Thêm khách hàng vào danh sách |
| | DataGridView | `dgvCustomers` | Hiển thị danh sách khách hàng |

---

## 4. Hướng dẫn thực hiện chương trình


   ```csharp
   ApplicationConfiguration.Initialize();
   FrmLogin login = new FrmLogin();
   if (login.ShowDialog() == DialogResult.OK)
   {
       Application.Run(new FrmMain(login.CurrentUser));
   }
