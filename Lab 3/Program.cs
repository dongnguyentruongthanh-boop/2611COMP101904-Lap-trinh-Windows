using System;
using System.Collections.Generic;

namespace Lab03_QuanLySinhVienOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            QuanLySinhVien qlsv = new QuanLySinhVien();
            int chon = -1;

            do
            {
                Console.WriteLine("\n===== QUAN LY SINH VIEN =====");
                Console.WriteLine("1. Them sinh vien");
                Console.WriteLine("2. Xuat danh sach");
                Console.WriteLine("3. Tim sinh vien theo ma");
                Console.WriteLine("4. Tim sinh vien theo ten");
                Console.WriteLine("5. Sua diem trung binh");
                Console.WriteLine("6. Xoa sinh vien");
                Console.WriteLine("7. Sap xep theo diem giam dan");
                Console.WriteLine("8. Loc sinh vien dat");
                Console.WriteLine("0. Thoat");
                Console.Write("Cho chon chuc nang: ");

                if (!int.TryParse(Console.ReadLine(), out chon))
                {
                    Console.WriteLine("Lua chon khong hop le. Vui long nhap lai so!");
                    continue;
                }

                switch (chon)
                {
                    case 1:
                        Console.Write("Nhap ma sinh vien: ");
                        string maSV = Console.ReadLine();
                        if (qlsv.KiemTraTrungMa(maSV))
                        {
                            Console.WriteLine("Ma sinh vien da ton tai!");
                            break;
                        }

                        Console.Write("Nhap ho ten: ");
                        string hoTen = Console.ReadLine();
                        Console.Write("Nhap ngay sinh: ");
                        string ngaySinh = Console.ReadLine();
                        Console.Write("Nhap ma lop: ");
                        string maLop = Console.ReadLine();

                        float dtb = 0;
                        while (true)
                        {
                            try
                            {
                                Console.Write("Nhap diem trung binh (0-10): ");
                                dtb = float.Parse(Console.ReadLine());
                                if (dtb >= 0 && dtb <= 10) break;
                                Console.WriteLine("Diem khong hop le, vui long nhap tu 0 den 10.");
                            }
                            catch
                            {
                                Console.WriteLine("Vui long nhap so hop le!");
                            }
                        }

                        SinhVien sv = new SinhVien(maSV, hoTen, ngaySinh, maLop, dtb);
                        qlsv.Them(sv);
                        Console.WriteLine("Them sinh vien thanh cong!");
                        break;

                    case 2:
                        var ds = qlsv.LayDanhSach();
                        if (ds.Count == 0)
                        {
                            Console.WriteLine("Danh sach sinh vien trống.");
                        }
                        else
                        {
                            Console.WriteLine("--- DANH SACH SINH VIEN ---");
                            foreach (var item in ds)
                            {
                                Console.WriteLine(item.LayThongTin());
                            }
                        }
                        break;

                    case 3:
                        Console.Write("Nhap ma sinh vien can tim: ");
                        string maTim = Console.ReadLine();
                        var kqTimMa = qlsv.TimTheoMa(maTim);
                        if (kqTimMa != null)
                        {
                            Console.WriteLine(kqTimMa.LayThongTin());
                        }
                        else
                        {
                            Console.WriteLine("Khong tim thay sinh vien co ma nay.");
                        }
                        break;

                    case 4:
                        Console.Write("Nhap tu khoa ho ten can tim: ");
                        string tenTim = Console.ReadLine();
                        var kqTimTen = qlsv.TimTheoTen(tenTim);
                        if (kqTimTen.Count > 0)
                        {
                            foreach (var item in kqTimTen)
                            {
                                Console.WriteLine(item.LayThongTin());
                            }
                        }
                        else
                        {
                            Console.WriteLine("Khong tìm thay sinh vien phu hop.");
                        }
                        break;

                    case 5:
                        Console.Write("Nhap ma sinh vien can sua diem: ");
                        string maSua = Console.ReadLine();
                        float diemMoi = 0;
                        while (true)
                        {
                            try
                            {
                                Console.Write("Nhap diem trung binh moi (0-10): ");
                                diemMoi = float.Parse(Console.ReadLine());
                                if (diemMoi >= 0 && diemMoi <= 10) break;
                                Console.WriteLine("Diem khong hop le, vui long nhap tu 0 den 10.");
                            }
                            catch
                            {
                                Console.WriteLine("Vui long nhap so hop le!");
                            }
                        }
                        qlsv.Sua(maSua, diemMoi);
                        break;

                    case 6:
                        Console.Write("Nhap ma sinh vien can xoa: ");
                        string maXoa = Console.ReadLine();
                        qlsv.Xoa(maXoa);
                        break;

                    case 7:
                        qlsv.SapXepTheoDiem();
                        Console.WriteLine("Da sap xep danh sach theo diem giam dan thanh cong!");
                        break;

                    case 8:
                        var dsDat = qlsv.LocSinhVienDat();
                        if (dsDat.Count == 0)
                        {
                            Console.WriteLine("Khong co sinh vien nao dat diem tu 5.0 tro len.");
                        }
                        else
                        {
                            Console.WriteLine("--- DANH SACH SINH VIEN DAT (>= 5.0) ---");
                            foreach (var item in dsDat)
                            {
                                Console.WriteLine(item.LayThongTin());
                            }
                        }
                        break;

                    case 0:
                        Console.WriteLine("Ket thuc chuong trinh.");
                        break;

                    default:
                        Console.WriteLine("Chuc nang khong ton tai. Vui long chon lai!");
                        break;
                }

            } while (chon != 0);
        }
    }
}