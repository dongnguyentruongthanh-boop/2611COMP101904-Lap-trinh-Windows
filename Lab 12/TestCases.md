# Test case - Lab 12

Điền cột "Kết quả" (Pass/Fail) sau khi tự chạy thử.

| STT | Tình huống | Các bước | Kết quả mong đợi | Kết quả |
|-----|-----------|----------|------------------|---------|
| 1 | Load ComboBox | Mở Form | cboLop có 2 lớp, cboMonHoc có 2 môn, hiển thị tên (không phải System.Data.DataRowView) | |
| 2 | Tải danh sách | Chọn CTK47A + Lập trình trên Windows, bấm Tải danh sách | Hiện 3 sinh viên; SV001 điểm 8.5, SV002 điểm 7, SV003 điểm 0 | |
| 3 | Cột chỉ đọc | Thử sửa cột Mã SV và Họ tên | Không sửa được; sửa được Điểm và Ghi chú | |
| 4 | Lưu hợp lệ | Nhập điểm cho SV003 = 6.5, bấm Lưu tất cả | Báo "Đã lưu thành công 3 dòng"; kiểm tra trong SSMS thấy SV003 có điểm 6.5 | |
| 5 | Cập nhật điểm cũ | Đổi điểm SV001 thành 9, Lưu tất cả | Điểm SV001 trong bảng KETQUA đổi thành 9, không bị trùng dòng | |
| 6 | Điểm > 10 | Nhập điểm 15, Lưu tất cả | Báo "phải từ 0 đến 10", không có dòng nào bị thay đổi trong database | |
| 7 | Điểm âm | Nhập điểm -1, Lưu tất cả | Báo lỗi, không lưu | |
| 8 | Điểm là chữ | Gõ "abc" vào ô Điểm | Hiện thông báo điểm phải là số, ô vẫn giữ giá trị cũ khi nhấn Esc | |
| 9 | Điểm để trống | Xóa trống ô Điểm của một dòng, Lưu tất cả | Báo điểm không hợp lệ, không lưu | |
| 10 | Chưa tải danh sách | Mở Form, bấm Lưu tất cả ngay | Báo "Vui lòng tải danh sách sinh viên trước" | |
| 11 | Rollback (kiểm thử thêm) | Tạm thời comment dòng `ValidateData(table);`, nhập SV001 = 9.5 và SV003 = 15, bấm Lưu tất cả | Database CHECK báo lỗi ở dòng SV003, SV001 vẫn giữ điểm cũ (rollback toàn bộ). Nhớ bỏ comment lại sau khi test | |
