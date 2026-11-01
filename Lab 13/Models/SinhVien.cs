namespace StudentReportDemo.Models
{
    public class SinhVien
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public double Diem { get; set; }

        // Chi doc: tinh tu Diem nen khong the bi sai lech
        public string KetQua
        {
            get
            {
                return Diem >= 5 ? "Đạt" : "Không đạt";
            }
        }
    }
}
