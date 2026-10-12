using System;

namespace Lab02_QuanLyMang
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = null; 
            int chon;

            do
            {
             
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Nhap mang");
                Console.WriteLine("2. Xuat mang");
                Console.WriteLine("3. Tinh tong");
                Console.WriteLine("4. Tim max/min");
                Console.WriteLine("5. Dem chan/le");
                Console.WriteLine("6. Sap xep tang dan");
                Console.WriteLine("7. Tim kiem");
                Console.WriteLine("0. Thoat");

                chon = NhapSoNguyen("Chon chuc nang: ");

                switch (chon)
                {
                    case 1:
                        a = NhapMang();
                        break;
                    case 2:
                        if (KiemTraMang(a)) XuatMang(a);
                        break;
                    case 3:
                        if (KiemTraMang(a))
                        {
                            int tong = TinhTong(a);
                            Console.WriteLine($"Tong cac phan tử trong mang la: {tong}");
                        }
                        break;
                    case 4:
                        if (KiemTraMang(a))
                        {
                            int max = TimMax(a);
                            int min = TimMin(a);
                            Console.WriteLine($"Gia tri lon nhat la: {max}");
                            Console.WriteLine($"Gia tri nho nhat la: {min}");
                        }
                        break;
                    case 5:
                        if (KiemTraMang(a))
                        {
                            int demChan = DemChan(a);
                            int demLe = DemLe(a);
                            Console.WriteLine($"So luong phan tu chan: {demChan}");
                            Console.WriteLine($"So luong phan tu le: {demLe}");
                        }
                        break;
                    case 6:
                        if (KiemTraMang(a))
                        {
                            SapXepTangDan(a);
                            Console.WriteLine("Mang sau khi sap xep tang dan la:");
                            XuatMang(a);
                        }
                        break;
                    case 7:
                        if (KiemTraMang(a))
                        {
                            int x = NhapSoNguyen("Nhap gia tri x can tim: ");
                            int vt = TimKiem(a, x);
                            if (vt != -1)
                            {
                                Console.WriteLine($"Tim thay {x} tai vi trí dau tien la: {vt}");
                            }
                            else
                            {
                                Console.WriteLine($"Khong tim thay {x} trong mang.");
                            }
                        }
                        break;
                    case 0:
                        Console.WriteLine("Cam on ban da su dung chuong trinh!");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le. Vui long chon tu 0 den 7!");
                        break;
                }

            } while (chon != 0);
        }


        static int NhapSoNguyen(string message)
        {
            int kq;
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (int.TryParse(input, out kq))
                {
                    return kq;
                }
                Console.WriteLine("Loi: Vui long nhap vao mot so nguyên hop le!");
            }
        }

       
        static int NhapSoNguyenDuong(string message)
        {
            int kq;
            while (true)
            {
                kq = NhapSoNguyen(message);
                if (kq > 0)
                {
                    return kq;
                }
                Console.WriteLine("Loi: So luong phai lon hon 0. Vui long nhap lai!");
            }
        }

       
        static bool KiemTraMang(int[] a)
        {
            if (a == null)
            {
                Console.WriteLine("Thong bao: Ban chua nhap mang! Vui long chon chuc nang 1 truoc.");
                return false;
            }
            return true;
        }

     
        static int[] NhapMang()
        {
            int n = NhapSoNguyenDuong("Nhap so luong phan tu n: ");
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = NhapSoNguyen($"Nhap phan tu a[{i}] = ");
            }
            return a;
        }

       
        static void XuatMang(int[] a)
        {
            Console.Write("Cac phan tu trong mang la: ");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }

     
        static int TinhTong(int[] a)
        {
            int tong = 0;
            for (int i = 0; i < a.Length; i++)
            {
                tong += a[i];
            }
            return tong;
        }

   
        static int TimMax(int[] a)
        {
            int max = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > max)
                {
                    max = a[i];
                }
            }
            return max;
        }

   
        static int TimMin(int[] a)
        {
            int min = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] < min)
                {
                    min = a[i];
                }
            }
            return min;
        }

     
        static int DemChan(int[] a)
        {
            int dem = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 2 == 0)
                {
                    dem++;
                }
            }
            return dem;
        }

    
        static int DemLe(int[] a)
        {
            int dem = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 2 != 0)
                {
                    dem++;
                }
            }
            return dem;
        }

        
        static void SapXepTangDan(int[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] > a[j])
                    {
                        int temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }
            }
        }

       
        static int TimKiem(int[] a, int x)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == x)
                {
                    return i; 
                }
            }
            return -1; 
        }
    }
}