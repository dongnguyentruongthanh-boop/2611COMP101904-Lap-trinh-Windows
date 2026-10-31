
-- Cac truy van cua bai lab 10 (12 yeu cau + 2 test them)
-- Chay tung cau mot (boi den roi bam Execute) de chup anh ket qua

USE EduManagerDB;
GO

-- 1. Liet ke toan bo sinh vien
SELECT MaSV, HoTen, NgaySinh, GioiTinh, MaLop
FROM SINHVIEN;
GO

-- 2. Sinh vien kem ten lop va ten khoa
SELECT sv.MaSV, sv.HoTen, l.TenLop, k.TenKhoa
FROM SINHVIEN sv
INNER JOIN LOP l  ON sv.MaLop  = l.MaLop
INNER JOIN KHOA k ON l.MaKhoa = k.MaKhoa;
GO

-- 3. Tim sinh vien theo mot phan ho ten (LIKE)
SELECT MaSV, HoTen, MaLop
FROM SINHVIEN
WHERE HoTen LIKE N'%Nguyễn%'
ORDER BY HoTen ASC;
GO

-- 4. Liet ke sinh vien theo ma lop
SELECT MaSV, HoTen, GioiTinh
FROM SINHVIEN
WHERE MaLop = 'CNTT01';
GO

-- 5. Cap nhat ho ten cua 1 sinh vien
-- (nho phai co WHERE, neu khong se doi het ca bang)
UPDATE SINHVIEN
SET HoTen = N'Nguyễn Văn An (đã sửa)'
WHERE MaSV = 'SV001';

-- xem lai ket qua
SELECT MaSV, HoTen FROM SINHVIEN WHERE MaSV = 'SV001';

-- cap nhat lop cua sinh vien cung lam tuong tu, vi du:
-- UPDATE SINHVIEN SET MaLop = 'CNTT01' WHERE MaSV = 'SV004';
GO

-- 6. Xoa sinh vien chua co du lieu diem
-- Tat ca 6 sinh vien mau deu da co diem nen em them SV007 de xoa thu
INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
VALUES ('SV007', N'Sinh viên xóa thử', '2005-05-05', N'Nam', 'CNTT01');

DELETE FROM SINHVIEN
WHERE MaSV = 'SV007'
  AND NOT EXISTS (SELECT 1 FROM KETQUA WHERE MaSV = 'SV007');

-- thu xoa SV003 (da co diem) thi se khong xoa duoc dong nao
DELETE FROM SINHVIEN
WHERE MaSV = 'SV003'
  AND NOT EXISTS (SELECT 1 FROM KETQUA WHERE MaSV = 'SV003');
GO

-- 7. Liet ke diem cua tung sinh vien theo tung mon
SELECT sv.MaSV, sv.HoTen, mh.TenMH, kq.Diem
FROM KETQUA kq
INNER JOIN SINHVIEN sv ON kq.MaSV = sv.MaSV
INNER JOIN MONHOC mh   ON kq.MaMH = mh.MaMH
ORDER BY sv.MaSV, mh.TenMH;
GO

-- 8. Diem trung binh cua tung sinh vien
SELECT sv.MaSV, sv.HoTen, AVG(kq.Diem) AS DiemTrungBinh
FROM SINHVIEN sv
INNER JOIN KETQUA kq ON sv.MaSV = kq.MaSV
GROUP BY sv.MaSV, sv.HoTen;
GO

-- 9. Thong ke so sinh vien theo tung lop
SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien
FROM LOP l
LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
GROUP BY l.MaLop, l.TenLop;
GO

-- 10. Cac lop co tu 2 sinh vien tro len
SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien
FROM LOP l
LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
GROUP BY l.MaLop, l.TenLop
HAVING COUNT(sv.MaSV) >= 2;
GO

-- ===== Test rang buoc: cac cau duoi day PHAI BAO LOI =====

-- 11. Them sinh vien vao lop khong ton tai (CNTT99) -> loi khoa ngoai
INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
VALUES ('SV999', N'Sinh viên lỗi', '2005-01-01', N'Nam', 'CNTT99');
GO

-- 12. Nhap diem ngoai khoang 0 - 10 (diem 12) -> loi CHECK
INSERT INTO KETQUA (MaSV, MaMH, Diem)
VALUES ('SV001', 'COMP1019', 12);
GO

-- 13. Gioi tinh khong phai Nam/Nu -> loi CHECK
INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
VALUES ('SV998', N'Sinh viên giới tính lỗi', '2005-01-01', N'Khác', 'CNTT01');
GO

-- 14. Trung ma sinh vien SV001 -> loi khoa chinh
INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
VALUES ('SV001', N'Trùng mã', '2005-01-01', N'Nam', 'CNTT01');
GO
