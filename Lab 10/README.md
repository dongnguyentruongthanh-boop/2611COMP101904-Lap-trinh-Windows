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
## Truy vấn liệt kệ sinh viên kèm tên và lớp:

<img width="671" height="148" alt="Screenshot 2026-10-31 202811" src="https://github.com/user-attachments/assets/e3fbbcb2-5341-4339-89de-dd0628ce5a19" />

## Các ràng buộc truy vấn

<img width="1280" height="256" alt="Screenshot 2026-10-31 202305" src="https://github.com/user-attachments/assets/3f32b401-28c0-4798-8969-f78dac806cc6" />

## Tính điểm trung bình
<img width="710" height="165" alt="Screenshot 2026-10-31 202836" src="https://github.com/user-attachments/assets/53fc014b-24dc-423e-91de-bfa62486560b" />

## Kết quả 
<img width="1473" height="181" alt="Screenshot 2026-10-31 202353" src="https://github.com/user-attachments/assets/30cc1ef7-e9c1-4988-9b24-bd93feeb9c6f" />

<img width="1462" height="322" alt="Screenshot 2026-10-31 202508" src="https://github.com/user-attachments/assets/2e46e5ec-e0a5-4fef-9418-87b3b84f9c69" />

<img width="1465" height="391" alt="Screenshot 2026-10-31 202452" src="https://github.com/user-attachments/assets/277fee0b-0798-466b-b031-434885a45c84" />

<img width="1477" height="343" alt="Screenshot 2026-10-31 202440" src="https://github.com/user-attachments/assets/6964b7b5-b7ff-4837-aaaf-10c450ff16e1" />

<img width="1442" height="216" alt="Screenshot 2026-10-31 202400" src="https://github.com/user-attachments/assets/3994036a-9861-4f02-98fe-b3a08991442f" />

