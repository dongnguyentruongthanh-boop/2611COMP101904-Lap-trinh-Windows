# Bài lab 10 - EduManagerDB (SQL Server)

Môn: COMP1019 - Lập trình trên Windows
Sinh viên: ........................  Lớp: ........................

## Các file
| File | Nội dung |
|------|----------|
| 01_CreateDatabase.sql | Tạo database EduManagerDB và 6 bảng (KHOA, LOP, SINHVIEN, MONHOC, KETQUA, TAIKHOAN) cùng khóa chính, khóa ngoại, ràng buộc CHECK |
| 02_InsertSampleData.sql | Dữ liệu mẫu: 2 khoa, 3 lớp, 6 sinh viên, 4 môn học, 8 kết quả, 2 tài khoản |
| 03_Queries.sql | 12 truy vấn theo đề (SELECT, JOIN, GROUP BY, UPDATE, DELETE) và 2 test lỗi thêm |

## Cách chạy
1. Mở SQL Server Management Studio (SSMS), kết nối vào server.
2. Mở và chạy lần lượt file 01, rồi 02, rồi 03 (bấm Execute hoặc F5).
3. File 03 nên bôi đen từng câu để chạy riêng và chụp ảnh kết quả.
4. Muốn chạy lại từ đầu thì chạy lại file 01, nó tự xóa database cũ.

## Các ràng buộc đã làm
- Khóa chính ở cả 6 bảng, KETQUA dùng khóa chính ghép (MaSV, MaMH).
- Khóa ngoại: LOP -> KHOA, SINHVIEN -> LOP, KETQUA -> SINHVIEN và MONHOC.
- CHECK: Diem từ 0 đến 10, GioiTinh chỉ nhận Nam hoặc Nữ, SoTinChi lớn hơn 0.

## Kết quả test lỗi (cuối file 03)
| Câu | Test | Lỗi SQL Server báo |
|-----|------|--------------------|
| 11 | Thêm sinh viên vào lớp CNTT99 | Msg 547, vi phạm FOREIGN KEY FK_SINHVIEN_LOP |
| 12 | Nhập điểm 12 | Msg 547, vi phạm CHECK CK_KETQUA_Diem |
| 13 | Giới tính "Khác" | Msg 547, vi phạm CHECK CK_SINHVIEN_GioiTinh |
| 14 | Trùng mã SV001 | Msg 2627, vi phạm PRIMARY KEY |

Bốn câu này báo lỗi là đúng, chứng tỏ ràng buộc đang hoạt động.

## Ghi chú
- Cả 6 sinh viên mẫu đều đã có điểm nên câu 6 em thêm sinh viên SV007 (chưa có điểm) để xóa thử. Câu xóa SV003 (đã có điểm) thì không xóa được dòng nào.
- File lưu dạng UTF-8 để tiếng Việt trong N'...' không bị lỗi font.
