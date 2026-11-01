
USE master;
GO

-- Xoa database cu neu co de chay lai tu dau
IF DB_ID('QLSinhVienLab12') IS NOT NULL
BEGIN
    ALTER DATABASE QLSinhVienLab12 SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QLSinhVienLab12;
END
GO

CREATE DATABASE QLSinhVienLab12;
GO

USE QLSinhVienLab12;
GO

-- ===== Bang =====
CREATE TABLE LOP (
    MaLop NVARCHAR(20) PRIMARY KEY,
    TenLop NVARCHAR(100) NOT NULL
);

CREATE TABLE SINHVIEN (
    MaSV NVARCHAR(20) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE NULL,
    MaLop NVARCHAR(20) NOT NULL,
    CONSTRAINT FK_SINHVIEN_LOP FOREIGN KEY (MaLop) REFERENCES LOP(MaLop)
);

CREATE TABLE MONHOC (
    MaMon NVARCHAR(20) PRIMARY KEY,
    TenMon NVARCHAR(100) NOT NULL,
    SoTinChi INT NOT NULL CHECK (SoTinChi > 0)
);

-- Khoa chinh (MaSV, MaMon): 1 sinh vien chi co 1 diem cho 1 mon
CREATE TABLE KETQUA (
    MaSV NVARCHAR(20) NOT NULL,
    MaMon NVARCHAR(20) NOT NULL,
    Diem FLOAT NOT NULL CHECK (Diem >= 0 AND Diem <= 10),
    GhiChu NVARCHAR(255) NULL,
    CONSTRAINT PK_KETQUA PRIMARY KEY (MaSV, MaMon),
    CONSTRAINT FK_KETQUA_SINHVIEN FOREIGN KEY (MaSV) REFERENCES SINHVIEN(MaSV),
    CONSTRAINT FK_KETQUA_MONHOC FOREIGN KEY (MaMon) REFERENCES MONHOC(MaMon)
);
GO

-- ===== Du lieu mau =====
INSERT INTO LOP VALUES
(N'CTK47A', N'Công nghệ thông tin K47A'),
(N'CTK47B', N'Công nghệ thông tin K47B');

INSERT INTO SINHVIEN VALUES
(N'SV001', N'Nguyễn Văn An',    '2005-01-15', N'CTK47A'),
(N'SV002', N'Trần Thị Bình',    '2005-05-20', N'CTK47A'),
(N'SV003', N'Lê Minh Cường',    '2005-03-11', N'CTK47A'),
(N'SV004', N'Phạm Thanh Dung',  '2005-07-09', N'CTK47B');

INSERT INTO MONHOC VALUES
(N'COMP1019', N'Lập trình trên Windows', 3),
(N'COMP1017', N'Cơ sở lập trình', 3);

-- vai diem co san de thay "kem diem neu da co"
INSERT INTO KETQUA(MaSV, MaMon, Diem, GhiChu) VALUES
(N'SV001', N'COMP1019', 8.5, N'Khá giỏi'),
(N'SV002', N'COMP1019', 7, N'');
GO

-- ===== Stored procedure =====

-- Lay danh sach lop
CREATE OR ALTER PROCEDURE sp_Lop_GetAll
AS
BEGIN
    SELECT MaLop, TenLop
    FROM LOP
    ORDER BY TenLop;
END;
GO

-- Lay danh sach mon hoc
CREATE OR ALTER PROCEDURE sp_MonHoc_GetAll
AS
BEGIN
    SELECT MaMon, TenMon, SoTinChi
    FROM MONHOC
    ORDER BY TenMon;
END;
GO

-- Lay sinh vien cua lop kem diem mon hoc (chua co diem thi hien 0)
CREATE OR ALTER PROCEDURE sp_KetQua_GetByLopMon
    @MaLop NVARCHAR(20),
    @MaMon NVARCHAR(20)
AS
BEGIN
    SELECT sv.MaSV,
           sv.HoTen,
           CAST(ISNULL(kq.Diem, 0) AS FLOAT) AS Diem,
           ISNULL(kq.GhiChu, N'') AS GhiChu
    FROM SINHVIEN sv
    LEFT JOIN KETQUA kq
        ON sv.MaSV = kq.MaSV AND kq.MaMon = @MaMon
    WHERE sv.MaLop = @MaLop
    ORDER BY sv.HoTen;
END;
GO

-- Luu diem: da co thi UPDATE, chua co thi INSERT
CREATE OR ALTER PROCEDURE sp_KetQua_Save
    @MaSV NVARCHAR(20),
    @MaMon NVARCHAR(20),
    @Diem FLOAT,
    @GhiChu NVARCHAR(255)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM KETQUA WHERE MaSV = @MaSV AND MaMon = @MaMon)
    BEGIN
        UPDATE KETQUA
        SET Diem = @Diem,
            GhiChu = @GhiChu
        WHERE MaSV = @MaSV AND MaMon = @MaMon;
    END
    ELSE
    BEGIN
        INSERT INTO KETQUA(MaSV, MaMon, Diem, GhiChu)
        VALUES(@MaSV, @MaMon, @Diem, @GhiChu);
    END
END;
GO

-- Kiem tra nhanh
EXEC sp_Lop_GetAll;
EXEC sp_MonHoc_GetAll;
EXEC sp_KetQua_GetByLopMon N'CTK47A', N'COMP1019';
GO
