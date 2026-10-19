using System;

namespace Lab_6
{
   
    public class Product
    {
        public string MaSP { get; set; }           
        public string TenSP { get; set; }          
        public string LoaiSP { get; set; }        
        public decimal DonGia { get; set; }       
        public int SoLuong { get; set; }          
        public DateTime NgayNhap { get; set; }     
        public bool ConKinhDoanh { get; set; }    
        public string DuongDanAnh { get; set; }    

      
        public Product()
        {
            NgayNhap = DateTime.Now;
            ConKinhDoanh = true;
            DuongDanAnh = string.Empty;
        }
        
        public Product(string maSP, string tenSP, string loaiSP, decimal donGia, int soLuong, DateTime ngayNhap, bool conKinhDoanh, string duongDanAnh = "")
        {
            MaSP = maSP;
            TenSP = tenSP;
            LoaiSP = loaiSP;
            DonGia = donGia;
            SoLuong = soLuong;
            NgayNhap = ngayNhap;
            ConKinhDoanh = conKinhDoanh;
            DuongDanAnh = duongDanAnh;
        }
    }
}