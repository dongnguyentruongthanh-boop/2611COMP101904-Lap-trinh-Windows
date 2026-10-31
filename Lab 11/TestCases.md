# Test case - Lab 11

Điền cột "Kết quả" (Pass/Fail) sau khi tự chạy thử.

| STT | Tình huống | Dữ liệu test | Kết quả mong đợi | Kết quả |
|-----|-----------|--------------|------------------|---------|
| 1 | Load Form | Mở FrmLop | Hiển thị danh sách lớp kèm số sinh viên | |
| 2 | Thêm hợp lệ | MaLop = TEST01, TenLop = Lớp test | Thêm thành công, lớp hiện trong danh sách | |
| 3 | Thêm thiếu mã | MaLop để trống | Thông báo "Vui lòng nhập mã lớp" | |
| 4 | Thêm thiếu tên | TenLop để trống | Thông báo "Vui lòng nhập tên lớp" | |
| 5 | Thêm trùng mã | MaLop = CNTT01 | Thông báo "Mã lớp đã tồn tại" | |
| 6 | Chọn dòng | Click dòng CNTT02 | Mã lớp và tên lớp hiện lên TextBox, ô mã bị khóa | |
| 7 | Sửa chưa chọn lớp | Gõ tên mới nhưng không click dòng nào, bấm Sửa | Thông báo "Vui lòng chọn lớp cần sửa" | |
| 8 | Sửa hợp lệ | Chọn TEST01, đổi tên lớp, bấm Sửa | Cập nhật thành công | |
| 9 | Xóa lớp chưa có sinh viên | Chọn TEST01, bấm Xóa, chọn Yes | Xóa thành công | |
| 10 | Xóa lớp đang có sinh viên | Chọn CNTT01, bấm Xóa | Thông báo "Không thể xóa lớp đang có sinh viên" | |
| 11 | Tìm kiếm | keyword = CNTT | Chỉ hiện các lớp CNTT01, CNTT02 | |
| 12 | Làm mới | Bấm Làm mới sau khi chọn một dòng | TextBox được xóa, ô mã được mở khóa, danh sách load lại | |
