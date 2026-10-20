using System;

namespace Lab03_QuanLySinhVienOOP
{
    public class SinhVien : Nguoi
    {
        private float diemTrungBinh;

        public string MaSinhVien { get; set; }
        public string MaLop { get; set; }

        public float DiemTrungBinh
        {
            get => diemTrungBinh;
            set
            {
                if (value >= 0 && value <= 10)
                {
                    diemTrungBinh = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Điểm trung bình phải nằm trong khoảng từ 0 đến 10.");
                }
            }
        }

        public SinhVien() : base() { }

        public SinhVien(string maSinhVien, string hoTen, string ngaySinh, string maLop, float diemTrungBinh)
            : base(hoTen, ngaySinh)
        {
            MaSinhVien = maSinhVien;
            MaLop = maLop;
            DiemTrungBinh = diemTrungBinh;
        }

        public string XepLoai()
        {
            if (DiemTrungBinh >= 8.0) return "Giỏi";
            if (DiemTrungBinh >= 6.5) return "Khá";
            if (DiemTrungBinh >= 5.0) return "Trung bình";
            return "Yếu";
        }

        public override string LayThongTin()
        {
            return $"Mã SV: {MaSinhVien} | Họ tên: {HoTen} | Ngày sinh: {NgaySinh} | Lớp: {MaLop} | ĐTB: {DiemTrungBinh} | Xếp loại: {XepLoai()}";
        }
    }
}