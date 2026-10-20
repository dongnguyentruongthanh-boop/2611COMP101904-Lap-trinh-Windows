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

1/ Giao diện
<img width="336" height="262" alt="Giao diện" src="https://github.com/user-attachments/assets/0ba4e678-729a-444b-9a80-1a593557cd25" />

2/ Sai tên hoặc mật khẩu

<img width="327" height="255" alt="Sai tên hoặc mật khẩu" src="https://github.com/user-attachments/assets/6087310c-08d7-43f1-bffe-b0610f036a90" />

3/ Quản lý khách hàng

<img width="975" height="638" alt="Quản lý khách hàng" src="https://github.com/user-attachments/assets/b537bd66-0e9f-4444-883f-de93a54eb48e" />

4/ Quản lý Đơn hàng

<img width="972" height="620" alt="Admin" src="https://github.com/user-attachments/assets/b8dfa264-731d-4dc0-8866-40ddee2f3575" />

5/ Giới thiệu

<img width="977" height="627" alt="Giới thiệu" src="https://github.com/user-attachments/assets/b74b8c4a-f130-40f2-ba87-6eb184a153fb" />


# Câu hỏi nộp kèm 

**1. SDI và MDI khác nhau như thế nào?**
SDI (Single Document Interface): mỗi cửa sổ là một Form độc lập, mở ra là một cửa sổ riêng trên màn hình (ví dụ Notepad cũ). MDI (Multiple Document Interface): có một Form cha (`IsMdiContainer = true`) chứa nhiều Form con bên trong nó, các Form con không ra ngoài được khung của Form cha (ví dụ như Excel bản cũ). Trong bài này FrmMain là MDI Parent, còn FrmProduct, FrmCustomer, FrmAbout là MDI Child (đặt `MdiParent = this`).

**2. Vì sao Form đăng nhập nên dùng ShowDialog()?**
`ShowDialog()` mở form ở dạng modal: chương trình dừng lại ở dòng gọi cho đến khi form đóng, nên người dùng phải đăng nhập xong mới làm tiếp được. Ngoài ra `ShowDialog()` trả về `DialogResult`, nhờ đó `Program.cs` biết đăng nhập thành công (`OK`) hay người dùng đã thoát (`Cancel`) để quyết định có mở FrmMain hay không.

**3. Dữ liệu user truyền từ FrmLogin sang FrmMain bằng cách nào?**
FrmLogin có property `LoggedUser` lưu tài khoản đăng nhập đúng. Sau khi `ShowDialog()` trả về `OK`, `Program.cs` lấy `frmLogin.LoggedUser` rồi truyền vào constructor của FrmMain: `new FrmMain(currentUser)`. FrmMain dùng user này để hiện tên và vai trò trên StatusStrip.

**4. Nếu người dùng bấm menu sản phẩm nhiều lần, chương trình xử lý như thế nào để không mở trùng Form?**
Trước khi tạo form mới, duyệt qua `this.MdiChildren` để xem đã có form cùng kiểu chưa (`f is FrmProduct`). Nếu có rồi thì đưa về trạng thái bình thường (nếu đang thu nhỏ) và gọi `Activate()`, không `new` thêm. Chỉ khi chưa có mới tạo mới. Phần này nằm trong hàm `OpenChild<T>()` của FrmMain.

**5. Khi nào nên dùng constructor, khi nào dùng property để truyền dữ liệu giữa các Form?**
- Constructor: dùng khi dữ liệu bắt buộc phải có ngay lúc form khởi tạo. Ví dụ `new FrmMain(user)`, `new FrmProduct(products)`.
- Property: dùng khi dữ liệu là tùy chọn, hoặc cần lấy kết quả ngược lại từ form con sau khi nó đóng, hoặc cần gán/đổi giá trị sau khi form đã được tạo. Ví dụ `FrmLogin.LoggedUser` để FrmMain/Program đọc kết quả sau khi đăng nhập.





