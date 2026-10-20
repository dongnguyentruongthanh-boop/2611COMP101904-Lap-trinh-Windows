using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab03_QuanLySinhVienOOP
{
    public class QuanLySinhVien
    {
        private List<SinhVien> danhSachSV = new List<SinhVien>();

        public void Them(SinhVien sv)
        {
            danhSachSV.Add(sv);
        }

        public void Sua(string maSV, float diemMoi)
        {
            SinhVien sv = TimTheoMa(maSV);
            if (sv != null)
            {
                sv.DiemTrungBinh = diemMoi;
                Console.WriteLine("Cập nhật điểm thành công!");
            }
            else
            {
                Console.WriteLine("Không tìm thấy mã sinh viên cần sửa!");
            }
        }

        public void Xoa(string maSV)
        {
            SinhVien sv = TimTheoMa(maSV);
            if (sv != null)
            {
                danhSachSV.Remove(sv);
                Console.WriteLine("Xóa sinh viên thành công!");
            }
            else
            {
                Console.WriteLine("Không tìm thấy mã sinh viên cần xóa!");
            }
        }

        public SinhVien TimTheoMa(string maSV)
        {
            return danhSachSV.FirstOrDefault(s => s.MaSinhVien.Equals(maSV, StringComparison.OrdinalIgnoreCase));
        }

        public List<SinhVien> TimTheoTen(string tuKhoa)
        {
            return danhSachSV.Where(s => s.HoTen.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        public void SapXepTheoDiem()
        {
            danhSachSV = danhSachSV.OrderByDescending(s => s.DiemTrungBinh).ToList();
        }

        public List<SinhVien> LocSinhVienDat()
        {
            return danhSachSV.Where(s => s.DiemTrungBinh >= 5.0).ToList();
        }

        public List<SinhVien> LayDanhSach()
        {
            return danhSachSV;
        }

        public bool KiemTraTrungMa(string maSV)
        {
            return danhSachSV.Any(s => s.MaSinhVien.Equals(maSV, StringComparison.OrdinalIgnoreCase));
        }
    }
}