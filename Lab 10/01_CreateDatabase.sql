
-- Bai lab 10 - COMP1019
-- Tao database EduManagerDB va 6 bang: KHOA, LOP, SINHVIEN, MONHOC, KETQUA, TAIKHOAN

USE master;
GO

-- Neu database cu con thi xoa di de chay lai tu dau
-- (dong het cac ket noi khac vao database truoc khi xoa)
IF DB_ID('EduManagerDB') IS NOT NULL
BEGIN
    ALTER DATABASE EduManagerDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE EduManagerDB;
END
GO

CREATE DATABASE EduManagerDB;
GO

USE EduManagerDB;
GO

-- Bang KHOA
CREATE TABLE KHOA (
    MaKhoa    VARCHAR(20)   PRIMARY KEY,
    TenKhoa   NVARCHAR(100) NOT NULL,
    DienThoai VARCHAR(15)   NULL
);
GO

-- Bang LOP: moi lop thuoc 1 khoa
CREATE TABLE LOP (
    MaLop  VARCHAR(20)   PRIMARY KEY,
    TenLop NVARCHAR(100) NOT NULL,
    MaKhoa VARCHAR(20)   NOT NULL,
    CONSTRAINT FK_LOP_KHOA
        FOREIGN KEY (MaKhoa) REFERENCES KHOA(MaKhoa)
);
GO

-- Bang SINHVIEN: moi sinh vien thuoc 1 lop
CREATE TABLE SINHVIEN (
    MaSV     VARCHAR(20)   PRIMARY KEY,
    HoTen    NVARCHAR(100) NOT NULL,
    NgaySinh DATE          NULL,
    GioiTinh NVARCHAR(10)  NOT NULL,
    MaLop    VARCHAR(20)   NOT NULL,
    -- gioi tinh chi nhan Nam hoac Nu
    CONSTRAINT CK_SINHVIEN_GioiTinh
        CHECK (GioiTinh IN (N'Nam', N'Nữ')),
    CONSTRAINT FK_SINHVIEN_LOP
        FOREIGN KEY (MaLop) REFERENCES LOP(MaLop)
);
GO

-- Bang MONHOC
CREATE TABLE MONHOC (
    MaMH     VARCHAR(20)   PRIMARY KEY,
    TenMH    NVARCHAR(100) NOT NULL,
    SoTinChi INT           NOT NULL,
    -- so tin chi phai lon hon 0
    CONSTRAINT CK_MONHOC_SoTinChi CHECK (SoTinChi > 0)
);
GO

-- Bang KETQUA: khoa chinh gom 2 cot (MaSV, MaMH)
-- de 1 sinh vien khong co 2 diem cho cung 1 mon
CREATE TABLE KETQUA (
    MaSV VARCHAR(20)  NOT NULL,
    MaMH VARCHAR(20)  NOT NULL,
    Diem DECIMAL(4,2) NOT NULL,
    CONSTRAINT PK_KETQUA PRIMARY KEY (MaSV, MaMH),
    -- diem tu 0 den 10
    CONSTRAINT CK_KETQUA_Diem CHECK (Diem BETWEEN 0 AND 10),
    CONSTRAINT FK_KETQUA_SINHVIEN
        FOREIGN KEY (MaSV) REFERENCES SINHVIEN(MaSV),
    CONSTRAINT FK_KETQUA_MONHOC
        FOREIGN KEY (MaMH) REFERENCES MONHOC(MaMH)
);
GO

-- Bang TAIKHOAN: luu tai khoan dang nhap demo
CREATE TABLE TAIKHOAN (
    TenDangNhap VARCHAR(50)   PRIMARY KEY,
    MatKhau     VARCHAR(100)  NOT NULL,
    HoTen       NVARCHAR(100) NOT NULL,
    VaiTro      VARCHAR(20)   NOT NULL DEFAULT 'User',
    TrangThai   BIT           NOT NULL DEFAULT 1
);
GO

-- Kiem tra nhanh: phai ra du 6 bang
SELECT name AS TenBang FROM sys.tables ORDER BY name;
GO
